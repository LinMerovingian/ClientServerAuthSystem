using System;
using System.Linq;
using System.Windows.Forms;

namespace Winform_Client
{
    public partial class RegisterNewUser : Form
    {
        Form1 m_MainForm;

        bool validUserNameChosen = false;
        bool validPasswordChosen = false;

        Random random = new Random();
        
        public RegisterNewUser(Form1 mainForm)
        {
            m_MainForm = mainForm;

            InitializeComponent();
        }

        private void PasswordBox1_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordsMatch();
        }

        private void PasswordBox2_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordsMatch();
        }
        
        private void CheckPasswordsMatch()
        {
            if (PasswordBox1.Text.Length > 0 || PasswordBox2.Text.Length > 0)
            {
                if (PasswordBox1.Text == PasswordBox2.Text)
                {
                    PasswordGreenTick.Visible = true;
                    PasswordRedCross.Visible = false;
                    validPasswordChosen = true;
                    if (validUserNameChosen)
                    {
                        RegisterButton.Enabled = true;
                    }
                }
                else
                {
                    PasswordGreenTick.Visible = false;
                    PasswordRedCross.Visible = true;
                    validPasswordChosen = false;
                    RegisterButton.Enabled = false;
                }
            }
            else
            {
                PasswordGreenTick.Visible = false;
                PasswordRedCross.Visible = false;
                validPasswordChosen = false;
                RegisterButton.Enabled = false;
            }
        }
        
        private void CheckNameAvailabilityButton_Click(object sender, EventArgs e)
        {
            if (UserNameChoice.Text.Length > 0)
            {
                String forbiddenChars = "? &^$#@!()+-,:;<>’\'-_*";
                foreach (char c in forbiddenChars)
                {
                    if (UserNameChoice.Text.Contains(c))
                    {
                        UserNameRejected();
                        return;
                    }
                }
                m_MainForm.checkNameAvailability(UserNameChoice.Text);
            }
        }
        
        public void UserNameAccepted()
        {
            UserNameGreenTick.Visible = true;
            UserNameRedCross.Visible = false;
            validUserNameChosen = true;
            if (validPasswordChosen)
            {
                RegisterButton.Enabled = true;
            }
        }
        
        public void UserNameRejected()
        {
            UserNameGreenTick.Visible = false;
            UserNameRedCross.Visible = true;
            validUserNameChosen = false;
            RegisterButton.Enabled = false;
        }
        
        private void UserNameChoice_TextChanged(object sender, EventArgs e)
        {
            if (validUserNameChosen)
            {
                validUserNameChosen = false;
                UserNameGreenTick.Visible = false;
                UserNameRedCross.Visible = false;
                RegisterButton.Enabled = false;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (validUserNameChosen && validPasswordChosen)
            {
                m_MainForm.sendNewUserInfo(UserNameChoice.Text + " " +
                                Encryption.encryptPasswordWithSalt(PasswordBox1.Text, out String salt) + " " +
                                salt);
            }
        }

        private delegate void AddTextDelegate(String s);
        
        public void ClearTextBoxes()
        {
            UserNameChoice.Clear();
            PasswordBox1.Clear();
            PasswordBox2.Clear();
        }
    }
}
