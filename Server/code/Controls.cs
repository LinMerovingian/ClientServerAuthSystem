using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    public class Controls
    {
        static String m_UserName;
        
        SQLTable t_Logins;
        SQLTable t_Users;

        // Table field name strings
        String f_Name = "name";
        String f_ID = "id";
        String f_SecurityLevel = "securityLevel";

        // Table value strings
        String v_True = "true";
        String v_False = "false";
        String v_Null = "null";

        // To add a new line in a winforms text window
        String newLine = "\r\n";
        
        public Controls(SQLTable _UserTable, SQLTable _LoginTable)
        {
            t_Users = _UserTable;
            t_Logins = _LoginTable;
        }
        
        public string Update(String thisUserName, String inputMessage)
        {
            m_UserName = thisUserName;

            // Parse inputMessage
            String[] input = inputMessage.Split(' ');

            // Initialise return outputMessage
            String outputMessage = "";

            switch (input[0].ToLower())
            {
                case "help":
                    outputMessage = "\r\nCommands are ....\r\n";
                    outputMessage += "help - for this screen\r\n";
                    outputMessage += "Help, I need somebody\r\n";
                    outputMessage += "Help, not just anybody\r\n";
                    outputMessage += "Help, you know I need someone, help\r\n";
                    outputMessage += newLine;
                    outputMessage += "When I was younger so much younger than today\r\n";
                    outputMessage += "I never needed anybody's help in any way\r\n";
                    outputMessage += "But now these days are gone, I'm not so self assured\r\n";
                    outputMessage += "Now I find I've changed my mind and opened up the doors\r\n";
                    outputMessage += newLine;
                    outputMessage += "Help me if you can, I'm feeling down\r\n";
                    outputMessage += "And I do appreciate you being round\r\n";
                    outputMessage += "Help me get my feet back on the ground\r\n";
                    outputMessage += "Won't you please, please help me\r\n";

                    break;

                case "big":
                    try
                    {
                        if (input[1].ToLower() == "rich")
                        {
                            return newLine + "Big big Rich.";
                        }
                        else if (input[1].ToLower() == "coco")
                        {
                            return newLine + "Hello CoCo.";
                        }
                        else
                        {
                            return newLine + "Small " + input[1];
                        }
                    }
                    catch (Exception)
                    {
                        //handle error
                        return newLine + "What's so big?";
                    }

                case "log":
                    // <Log> prefix informs the program.cs to Log something
                    outputMessage = "<Log> <" + m_UserName + "> ";

                    for (var i = 1; i < input.Length; i++)
                    {
                        outputMessage += input[i] + " ";
                    }
                    break;

                case "gate":
                    outputMessage = "<AuthenticateRequested>";
                    break;

                default:
                    //handle error
                    outputMessage = "\r\nERROR";
                    outputMessage += "\r\nCan not " + inputMessage + ".";
                    break;
            }

            return outputMessage;
        }
    }
}
