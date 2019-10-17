using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform_Client
{
    public partial class RenewPassword : Form
    {
        Form1 mMainForm;

        string mUserName;

        bool validPasswordChosen = false;
        bool validPasswordEnteredTwice = false;

        public RenewPassword(Form1 mainForm, string userName)
        {
            mMainForm = mainForm;
            mUserName = userName;

            InitializeComponent();
        }

        private void PreviousPassword_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordsMatch();
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
            validPasswordChosen = false;

            if (PasswordBox1.Text.Length > 0)
            {
                if (PasswordBox1.Text.Length >= 8 && PasswordBox1.Text != PreviousPassword.Text)
                {
                    bool containsUpper = false;
                    bool containsLower = false;
                    bool containsNumber = false;

                    foreach (char c in PasswordBox1.Text)
                    {
                        if (char.IsUpper(c)) containsUpper = true;
                        else if (char.IsLower(c)) containsLower = true;
                        else if (char.IsNumber(c)) containsNumber = true;
                    }

                    if (containsUpper && containsLower && containsNumber)
                    {
                        validPasswordChosen = true;
                    }
                }

                if (validPasswordChosen)
                {
                    Password1GreenTick.Visible = true;
                    Password1RedCross.Visible = false;
                }
                else
                {
                    Password1GreenTick.Visible = false;
                    Password1RedCross.Visible = true;
                }
            }
            else
            {
                Password1GreenTick.Visible = false;
                Password1RedCross.Visible = false;
            }

            if (PreviousPassword.Text.Length > 0 && PasswordBox1.Text.Length > 0 && PasswordBox2.Text.Length > 0)
            {
                if (validPasswordChosen && PasswordBox1.Text == PasswordBox2.Text)
                {
                    Password2GreenTick.Visible = true;
                    Password2RedCross.Visible = false;
                    validPasswordEnteredTwice = true;
                    if (PreviousPassword.Text != PasswordBox1.Text)
                    {
                        RenewButton.Enabled = true;
                    }
                }
                else
                {
                    Password2GreenTick.Visible = false;
                    Password2RedCross.Visible = true;
                    validPasswordEnteredTwice = false;
                    RenewButton.Enabled = false;
                }
            }
            else
            {
                Password2GreenTick.Visible = false;
                Password2RedCross.Visible = false;
                validPasswordEnteredTwice = false;
                RenewButton.Enabled = false;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RenewButton_Click(object sender, EventArgs e)
        {
            if (validPasswordEnteredTwice)
            {
                mMainForm.sendNewPasswordInfo(mUserName + " " +
                                Encryption.encryptPasswordWithSalt(PasswordBox1.Text, out String salt) + " " +
                                salt);
            }
        }

        private delegate void AddTextDelegate(String s);

        public void ClearTextBoxes()
        {
            PreviousPassword.Clear();
            PasswordBox1.Clear();
            PasswordBox2.Clear();
            IncorrectPasswordLabel.Visible = false;
        }

        public void IncorrectPreviousPasswordEntered()
        {
            PreviousPassword.Clear();
            PasswordBox1.Clear();
            PasswordBox2.Clear();
            IncorrectPasswordLabel.Visible = true;
        }
    }
}
