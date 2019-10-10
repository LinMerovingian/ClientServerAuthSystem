using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using MessageTypes;

namespace Winform_Client
{
    public partial class Form1 : Form
    {
        public Socket m_Server;
        private Thread m_Thread;
        bool m_Quit = false;
        bool m_Connected = false;
        List<String> m_CurrentClientList = new List<String>();
        
        static Form1 m_MainForm;
        static LoginForm m_LoginForm;
        static RegisterNewUser m_RegisterNewUserForm;
        
        public Form1()
        {
            m_MainForm = this;
            InitializeComponent();

            // Hide the main form until login is complete and program starts
            Hide();
            m_Thread = new Thread(clientProcess);
            m_Thread.Start(this);

            Application.ApplicationExit += delegate { OnExit(); };
        }

        /*
         * Connect to the server
         */
        static public void clientProcess(Object o)
        {            
            Form1 form = (Form1)o;
            
            while ((form.m_Connected == false) && (form.m_Quit == false))
            {
                try
                {
                    form.m_Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    form.m_Server.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8500));//"165.227.227.143" "192.168.1.224"
                    form.m_Connected = true;

                    m_MainForm.Invoke(new MethodInvoker(delegate ()
                    {
                        m_LoginForm.showConnectedMessage();
                    }));

                    Thread receiveThread = new Thread(clientReceive);
                    receiveThread.Start(o);

                    while ((form.m_Quit == false) && (form.m_Connected == true))
                    {
                        if (form.IsDisposed == true)
                        {
                            form.m_Quit = true;
                            form.m_Server.Close();
                        }
                    }                    

                    receiveThread.Abort();
                }
                catch (System.Exception)
                {
                    m_MainForm.Enabled = false;

                    if (m_LoginForm.Visible == false)
                        m_LoginForm.ShowDialog();

                    // Invokes access cross thread functions
                    m_LoginForm.Invoke(new MethodInvoker(delegate ()
                    {
                        m_LoginForm.showDisconnectedMessage();
                    }));
                    m_MainForm.Invoke(new MethodInvoker(delegate ()
                    {
                        m_MainForm.Hide();
                    }));

                    form.AddMessageText("No server!");
                    Thread.Sleep(1000);
                }
            }
            Application.Restart();
        }

        /*
         * Receive messages from the server
         */
        static void clientReceive(Object o)
        {
            Form1 form = (Form1)o;

            while (form.m_Connected == true)
            {
                try
                {
                    byte[] buffer = new byte[4096];

                    if (form.m_Server.Receive(buffer) > 0)
                    {
                        MemoryStream stream = new MemoryStream(buffer);
                        BinaryReader read = new BinaryReader(stream);

                        Msg m = Msg.DecodeStream(read);

                        if (m != null)
                        {
                            switch (m.mID)
                            {
                                case ClientNameMsg.ID:
                                    {
                                        ClientNameMsg clientName = (ClientNameMsg)m;
                                        form.SetClientName(clientName.name);
                                    }
                                    break;

                                case ActionMsg.ID:
                                    {
                                        ActionMsg actionMessage = (ActionMsg)m;
                                        form.AddActionText(actionMessage.msg);
                                    }
                                    break;

                                case LoginMsg.ID:
                                    {
                                        LoginMsg recievedLoginMsg = (LoginMsg)m;
                                        switch (recievedLoginMsg.msg)
                                        {
                                            case "LoginAccepted":
                                                m_MainForm.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    m_LoginForm.Close();
                                                    m_MainForm.Enabled = true;
                                                    m_MainForm.Show();
                                                    m_MainForm.WindowState = FormWindowState.Normal;
                                                    
                                                }));

                                                break;

                                            case "LoginFailed":
                                                m_MainForm.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    // Clear text boxes and display error message
                                                    m_LoginForm.ClearTextBoxes("Incorrect login details");
                                                }));
                                                break;

                                            case "UserAlreadyLoggedIn":
                                                m_MainForm.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    // Clear text boxes and display error message
                                                    m_LoginForm.ClearTextBoxes("User logged in already");
                                                }));
                                                break;

                                            default:
                                                // If not one of the above confirm/deny strings then the message is the password salt sent back from the server in order to compare password hashs.
                                                Byte[] salt = Convert.FromBase64String(recievedLoginMsg.msg);

                                                m_MainForm.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    // Handing the salt back to the login form as we don't want to store the plaintext password anywhere, it is only ever read from the password box
                                                    m_LoginForm.logInWithSaltedHash(salt);
                                                }));
                                                break;
                                        }
                                    }
                                    break;

                                case CreateNewUserMsg.ID:
                                    {
                                        // Returned through new user creation process
                                        CreateNewUserMsg recievedNameCheck = (CreateNewUserMsg)m;
                                        switch (recievedNameCheck.msg)
                                        {
                                            case "NameAvailable":
                                                m_MainForm.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    m_RegisterNewUserForm.UserNameAccepted();
                                                }));
                                                break;

                                            case "NameTaken":
                                                m_MainForm.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    m_RegisterNewUserForm.UserNameRejected();
                                                }));
                                                break;

                                            case "Success":
                                                m_MainForm.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    m_RegisterNewUserForm.Close();
                                                }));
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    form.m_Connected = false;
                    Console.WriteLine("Lost server!");
                    try
                    {
                        m_MainForm.Enabled = false;
                        
                        // if the login window is closed
                        if (m_LoginForm.Visible == false)
                            m_LoginForm.ShowDialog();

                        m_MainForm.Invoke(new MethodInvoker(delegate ()
                        {
                            m_LoginForm.showDisconnectedMessage();
                            m_MainForm.Hide();
                        }));
                    }
                    catch { }
                }
            }
            Application.Restart();
        }

        private delegate void AddTextDelegate(String s);
        
        private void AddActionText(String s)
        {
            if (textBox_Output.InvokeRequired)
            {
                Invoke(new AddTextDelegate(AddActionText), new object[] { s });
            }
            else
            {
                // Comment out the following line to give a steady stream of previous messages to scroll back through
                textBox_Output.Text = "----------";

                // Append will scroll the textbox to the end of the new string, then add a new line
                textBox_Output.AppendText("\r\n" + s + "\r\n");
            }
        }
        
        private void AddMessageText(String s)
        {
            if (textBox_Output.InvokeRequired)
            {
                Invoke(new AddTextDelegate(AddMessageText), new object[] { s });
            }
            else
            {
                textBox_Output.AppendText("\r\n" + s + "\r\n");
            }
        }
        
        private delegate void SetClientNameDelegate(String s);
        private void SetClientName(String s)
        {
            if (this.InvokeRequired)
            {
                Invoke(new SetClientNameDelegate(SetClientName), new object[] {s});
            }
            else
            {
                Text = s;
            }
        }
        
        public void sendNewUserInfo(String newUserInfoString)
        {
            CreateNewUserMsg newUserMsg = new CreateNewUserMsg();
            newUserMsg.msg = newUserInfoString;
            MemoryStream outStream = newUserMsg.WriteData();
            m_Server.Send(outStream.GetBuffer());
        }
        
        public void checkNameAvailability(String userName)
        {
            sendNewUserInfo(userName);
        }

        public void sendLoginDetails(String loginDetails)
        {
            LoginMsg loginMsg = new LoginMsg();
            loginMsg.msg = loginDetails;
            MemoryStream outStream = loginMsg.WriteData();
            m_Server.Send(outStream.GetBuffer());
            
            m_MainForm.Invoke(new MethodInvoker(delegate ()
            {
                m_MainForm.SetClientName(loginDetails.Split(' ')[0]);
            }));
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (textBox_Input.Text.Length > 0)
            {
                if (m_Server != null)
                {
                    try
                    {
                        ActionMsg actionMessage = new ActionMsg();
                        actionMessage.msg = SanitiseString(textBox_Input.Text);
                        MemoryStream outStream = actionMessage.WriteData();
                        m_Server.Send(outStream.GetBuffer());
                    }
                    catch (System.Exception ex)
                    {
                        AddActionText(ex.ToString());
                    }
                    textBox_Input.Text = "";
                }
            }
        }
        
        public string SanitiseString(string dirtyString)
        {
            HashSet<char> removeChars = new HashSet<char>("?&^$#@!()+-,:;<>’\'-_*");
            StringBuilder result = new StringBuilder(dirtyString.Length);
            foreach (char c in dirtyString)
                if (!removeChars.Contains(c)) // prevent dirty chars
                    result.Append(c);
            return result.ToString();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            m_RegisterNewUserForm = new RegisterNewUser(this);
            m_LoginForm = new LoginForm(this, m_RegisterNewUserForm);
            m_LoginForm.ShowDialog();
        }

        private void OnExit()
        {
            m_Quit = true;
            Thread.Sleep(500);
            if (m_Thread != null)
            {
                m_Thread.Abort();
            }
        }
        
        private void SendActionMessage(String message)
        {
            ActionMsg actionMessage = new ActionMsg();
            actionMessage.msg = message;
            MemoryStream outStream = actionMessage.WriteData();
            m_Server.Send(outStream.GetBuffer());
        }
    }
}
