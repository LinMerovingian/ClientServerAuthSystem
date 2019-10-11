using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using MessageTypes;

namespace Server
{
    class Program
    {
        static String serverIPAddress = "127.0.0.1";
        
        static LoginTable m_LoginsTable;
        static UsersTable m_UserTable;
        static IdTable m_IDTable;

        static SQLDatabase m_Database;
        static Controls controls;

        static Dictionary<String, Socket> m_UserSocketDictionary = new Dictionary<String, Socket>();
        
        static void SendActionMessage(Socket _s, String _from, String _msg)
        {
            ActionMsg actionMessage = new ActionMsg();
            actionMessage.msg = _msg;
            actionMessage.destination = _from;
            MemoryStream outStream = actionMessage.WriteData();

            try
            {
                _s.Send(outStream.GetBuffer());
            }
            catch (System.Exception) { }
        }
        
        static void SendNewUserMessage(Socket _s, String _msg)
        {
            CreateNewUserMsg newUserMessage = new CreateNewUserMsg();
            newUserMessage.msg = _msg;
            MemoryStream outStream = newUserMessage.WriteData();

            try
            {
                _s.Send(outStream.GetBuffer());
            }
            catch (System.Exception) { }
        }
        
        static void SendLoginMessage(Socket _s, String _msg)
        {
            LoginMsg loginMessage = new LoginMsg();
            loginMessage.msg = _msg;
            MemoryStream outStream = loginMessage.WriteData();

            try
            {
                _s.Send(outStream.GetBuffer());
            }
            catch (System.Exception) { }
        }
        
        static Socket GetSocketFromName(String _name)
        {
            lock (m_UserSocketDictionary)
            {
                return m_UserSocketDictionary[_name];
            }
        }
        
        static String GetNameFromSocket(Socket _socket)
        {
            lock (m_UserSocketDictionary)
            {
                foreach (KeyValuePair<String, Socket> pair in m_UserSocketDictionary)
                {
                    if (pair.Value == _socket)
                    {
                        return pair.Key;
                    }
                }
            }
            // else
            return null;
        }
        
        static void ReceiveClientProcess(Object _socket)
        {
            bool bQuit = false;

            Socket clientSocket = (Socket)_socket;
            
            Console.WriteLine("client receive new user thread");
            
            String sendMsg = "";

            while (bQuit == false)
            {
                try
                {
                    byte[] buffer = new byte[4096];
                    int result;

                    result = clientSocket.Receive(buffer);

                    if (result > 0)
                    {
                        MemoryStream stream = new MemoryStream(buffer);
                        BinaryReader read = new BinaryReader(stream);

                        Msg message = Msg.DecodeStream(read);

                        if (message != null)
                        {
                            Console.Write("Client action: " + clientSocket);
                            switch (message.mID)
                            {
                                case ActionMsg.ID:
                                    {
                                        ActionMsg actionMessage = (ActionMsg)message;
                                        
                                        String formattedMsg = actionMessage.msg;
                                        
                                        String clientName = GetNameFromSocket(clientSocket);
                                        
                                        lock (m_UserSocketDictionary)
                                        {
                                            String thisUserName = GetNameFromSocket(clientSocket);

                                            sendMsg = controls.Update(clientName, formattedMsg);
                                            
                                            Console.WriteLine(sendMsg);

                                            try
                                            {
                                                if (sendMsg.Substring(0, 12) == "<HelloWorld>")
                                                {
                                                    SendActionMessage(clientSocket, "", sendMsg + " Big Rich");
                                                }
                                            }
                                            catch { }
                                            
                                            // If sendMsg conditions have not returned true for any of the above specific cases, then send the message back to the player socket
                                            SendActionMessage(clientSocket, "", sendMsg);
                                        }
                                    }
                                    break;

                                case CreateNewUserMsg.ID:
                                    {
                                        CreateNewUserMsg createNewUserMessage = (CreateNewUserMsg)message;
                                        String newLoginInfo = createNewUserMessage.msg;

                                        // Safe to split with this as no spaces allowed in username or password
                                        String[] processedLoginInfo = newLoginInfo.Split(' ');

                                        // If length == 1 then the client is performing a username availability check on the database
                                        if (processedLoginInfo.Length == 1)
                                        {
                                            if (m_LoginsTable.queryExists(processedLoginInfo[0], "name"))
                                            {
                                                SendNewUserMessage(clientSocket, "NameTaken");
                                            }
                                            else
                                            {
                                                SendNewUserMessage(clientSocket, "NameAvailable");
                                            }
                                        }
                                        else
                                        {
                                            // The position of the user name in the message
                                            String userName = processedLoginInfo[0];

                                            // Someone else may have taken the userName since it was checked last so do one more quick check
                                            if (m_LoginsTable.queryExists(userName, "name"))
                                            {
                                                SendNewUserMessage(clientSocket, "NameTaken");
                                            }
                                            else
                                            {
                                                // Tells the client to close it's 'registerNewUser' window
                                                SendNewUserMessage(clientSocket, "Success");

                                                // Get the unique id first so as to use the same ID in the user table and the login table to link them together
                                                String uniqueID = GetNextUniqueID().ToString();

                                                // Add the new user details to the logins table
                                                m_LoginsTable.AddEntry(new string[]
                                                {
                                                    // Starting values
                                                    userName,                       // name
                                                    processedLoginInfo[1],          // password
                                                    processedLoginInfo[2],          // salt
                                                    "false",                        // is logged in
                                                    uniqueID                        // Id (not currently used as each name is unique)
                                                });

                                                // Add the new user details to the users table
                                                m_UserTable.AddEntry(new string[]
                                                {
                                                    userName,                       // name
                                                    uniqueID,                       // Id (the same one as used in the login table)
                                                    "0"                             // Security level
                                                });
                                            }
                                        }
                                    }
                                    break;

                                case LoginMsg.ID:

                                    LoginMsg loginAttempt = (LoginMsg)message;
                                    String loginAttemptMessage = loginAttempt.msg;
                                    String[] processedLoginMessage = loginAttemptMessage.Split(' ');

                                    // The position of the user name in the message
                                    String submittedUserName = processedLoginMessage[0];

                                    // First check is whether the logins table contains a record of this username
                                    if (!m_LoginsTable.queryExists(submittedUserName, "name"))
                                    {
                                        SendLoginMessage(clientSocket, "LoginFailed");
                                    }
                                    // Else if client is requesting salt
                                    else if (processedLoginMessage[1] == "RequestSalt")
                                    {
                                        if (m_LoginsTable.getStringFieldFromName(submittedUserName, "isLoggedIn") == "false")
                                        {
                                            String salt = m_LoginsTable.getStringFieldFromName(submittedUserName, "passwordSalt");
                                            SendLoginMessage(clientSocket, salt);
                                        }
                                        else
                                        {
                                            SendLoginMessage(clientSocket, "UserAlreadyLoggedIn");
                                        }
                                    }
                                    else
                                    {
                                        // Get the database copy of the hashed salted password
                                        String databaseHash = m_LoginsTable.getStringFieldFromName(submittedUserName, "passwordHash");
                                        
                                        // Compare against the hashed salted password sent in the login message
                                        if (processedLoginMessage[1] == databaseHash)
                                        {
                                            SendLoginMessage(clientSocket, "LoginAccepted");
                                            
                                            m_UserSocketDictionary[submittedUserName] = clientSocket;
                                            
                                            m_LoginsTable.setFieldFromName(submittedUserName, "true", "isLoggedIn");

                                            // Initial message to client
                                            SendActionMessage(clientSocket, "", "Welcome user");
                                        }
                                        else
                                        {
                                            SendLoginMessage(clientSocket, "LoginFailed");
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                
                // Remove user from process
                catch (Exception)
                {
                    bQuit = true;
                    
                    String output = "Lost client: " + GetNameFromSocket(clientSocket);
                    
                    Console.WriteLine(output);

                    // Log user disconnected?

                    // Try to adjust the isLoggedIn field as the client may disconnect before they have logged in successfully
                    try
                    {
                        // Allow the client to log back in if disconnected
                        m_LoginsTable.setFieldFromName(GetNameFromSocket(clientSocket), "false", "isLoggedIn");
                    }
                    catch { }
                    
                    lock (m_UserSocketDictionary)
                    {
                        try
                        {
                            // Sanity check, then remove player information from playerDictionary
                            if (m_UserSocketDictionary.ContainsKey(GetNameFromSocket(clientSocket)))
                                m_UserSocketDictionary.Remove(GetNameFromSocket(clientSocket));
                        }
                        catch (Exception)
                        { }
                    }
                    
                    // Log action?
                }
            }
        }
        


        static void Main(string[] args)
        {
            m_Database = new SQLDatabase("database");
            
            m_LoginsTable = m_Database.addLoginTable("logins",
                "name varchar(20) NOT NULL, " +
                "passwordHash varchar(512) NOT NULL, " +
                "passwordSalt varchar(512) NOT NULL, " +
                "isLoggedIn varchar(8), " +
                "id int NOT NULL");
            
            m_UserTable = m_Database.addUsersTable("users",
                "name varchar(24) NOT NULL, " +
                "id int NOT NULL, " +
                "securityLevel int NOT NULL");
                
            m_IDTable = m_Database.addIDTable("ID",
                "name varchar(24) NOT NULL, " +
                "nextID int");

            m_LoginsTable.AddEntry(new string[] { "admin", "J1NF8m6ZRuDcx/5038/xP/zVdHPwg2YEdpOZvEVRFCw=", "IxBicNFzHtBa5GBFOuZTatjPTmVvgQ0JQ5NHwp+BOTI=", "false", "0" } );
            m_UserTable.AddEntry(new string[] { "admin", "0", "999" });

            m_IDTable.AddIDEntry("next", 1);

            controls = new Controls(m_UserTable, m_LoginsTable);
            
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Local address
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(serverIPAddress), 8500));
            
            serverSocket.Listen(32);

            bool bQuit = false;
            
            Console.WriteLine("This is the server!");

            while (!bQuit)
            {
                // When there is a new connection, create a new socket reference
                Socket serverClient = serverSocket.Accept();

                // Start a new thread assigned to this socket
                Thread myThread = new Thread(ReceiveClientProcess);
                myThread.Start(serverClient);

                Thread.Sleep(500);

                // Perform any new connection actions. Log timestamp etc
            }
        }
        
        static public int GetNextUniqueID()
        {
            // get the current unused value from the ID table, field nextID
            int i = m_IDTable.getIntFieldFromName("next", "nextID");
            
            m_IDTable.setFieldFromName("next", i+1, "nextID");
            
            return i;
        }
    }
}
