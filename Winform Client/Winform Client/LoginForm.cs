using System;
using System.Windows.Forms;

namespace Winform_Client
{
    public partial class LoginForm : Form
    {
        Form1 m_MainForm;
        
        RegisterNewUser m_RegisterNewUserForm;
        
        bool m_IsConnected = false;
        
        public LoginForm(Form1 mainform, RegisterNewUser registerNewUserForm)
        {
            m_MainForm = mainform;
            m_RegisterNewUserForm = registerNewUserForm;
            InitializeComponent();
        }
        
        private void Register_Click(object sender, EventArgs e)
        {
            m_RegisterNewUserForm.ClearTextBoxes();
            m_RegisterNewUserForm.ShowDialog();
        }
        
        public void ClearTextBoxes(String errorMessage)
        {
            UserName.Clear();
            Password.Clear();
            loginSuccessMessage.Text = errorMessage;
        }

        /*
         * Tells the main form to send a login details message.
         * 
         * This starts the authentication process:
         * 
         * 1. Send the userName to the server with a request for the salt
         * 2. The server looks up the userName in the user database and sends back the user specific salt stored against that existing userName
         * 3. Upon receiving the salt, the client encrypts the string currently entered in the password_textbox (never storing the string plain text anywhere) and sends
         *      it back to the server with the userName
         * 4. Upon recieving both the userName and the encrypted(password + salt), the server compares this against the encrypted(password + salt) it has stored for that username
         * 5. If identical, then the password is correct, the server returns "Success" and the main form will start
         */
        private void LoginButton_Click(object sender, EventArgs e)
        {
            m_MainForm.sendLoginDetails(UserName.Text + " RequestSalt");
        }
        
        public void showConnectedMessage()
        {
            ConnectedMessage.Text = "Connected";
            RegisterButton.Enabled = true;
            m_IsConnected = true;
            
            if (m_IsConnected && UserName.Text.Length > 0 && Password.Text.Length > 0)
            {
                LoginButton.Enabled = true;
            }
        }
        
        public void showDisconnectedMessage()
        {
            ConnectedMessage.Text = "Not connected";
            RegisterButton.Enabled = false;
            LoginButton.Enabled = false;
            m_IsConnected = false;
        }
        
        public void logInWithSaltedHash(Byte[] salt)
        {
            m_MainForm.sendLoginDetails(UserName.Text + " " + Encryption.encryptPasswordWithSalt(Password.Text, salt));
        }
        
        private void UserName_TextChanged(object sender, EventArgs e)
        {
            if (m_IsConnected && UserName.Text.Length > 0 && Password.Text.Length > 0)
            {
                LoginButton.Enabled = true;
            }
        }
        
        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (m_IsConnected && UserName.Text.Length > 0 && Password.Text.Length > 0)
            {
                LoginButton.Enabled = true;
            }
        }
    }
}
