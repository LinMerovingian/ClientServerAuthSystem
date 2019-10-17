namespace Winform_Client
{
    partial class RenewPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenewPassword));
            this.Password1RedCross = new System.Windows.Forms.PictureBox();
            this.Password1GreenTick = new System.Windows.Forms.PictureBox();
            this.Password2RedCross = new System.Windows.Forms.PictureBox();
            this.Password2GreenTick = new System.Windows.Forms.PictureBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.RenewButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordBox2 = new System.Windows.Forms.TextBox();
            this.PreviousPassword = new System.Windows.Forms.TextBox();
            this.PasswordBox1 = new System.Windows.Forms.TextBox();
            this.IncorrectPasswordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Password1RedCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password1GreenTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password2RedCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password2GreenTick)).BeginInit();
            this.SuspendLayout();
            // 
            // Password1RedCross
            // 
            this.Password1RedCross.Image = global::Winform_Client.Properties.Resources.RedCross;
            this.Password1RedCross.InitialImage = ((System.Drawing.Image)(resources.GetObject("Password1RedCross.InitialImage")));
            this.Password1RedCross.Location = new System.Drawing.Point(308, 103);
            this.Password1RedCross.Margin = new System.Windows.Forms.Padding(2);
            this.Password1RedCross.Name = "Password1RedCross";
            this.Password1RedCross.Size = new System.Drawing.Size(18, 17);
            this.Password1RedCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Password1RedCross.TabIndex = 31;
            this.Password1RedCross.TabStop = false;
            this.Password1RedCross.Visible = false;
            // 
            // Password1GreenTick
            // 
            this.Password1GreenTick.Image = global::Winform_Client.Properties.Resources.GreenTick;
            this.Password1GreenTick.InitialImage = ((System.Drawing.Image)(resources.GetObject("Password1GreenTick.InitialImage")));
            this.Password1GreenTick.Location = new System.Drawing.Point(308, 97);
            this.Password1GreenTick.Margin = new System.Windows.Forms.Padding(2);
            this.Password1GreenTick.Name = "Password1GreenTick";
            this.Password1GreenTick.Size = new System.Drawing.Size(29, 29);
            this.Password1GreenTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Password1GreenTick.TabIndex = 30;
            this.Password1GreenTick.TabStop = false;
            this.Password1GreenTick.Visible = false;
            // 
            // Password2RedCross
            // 
            this.Password2RedCross.Image = global::Winform_Client.Properties.Resources.RedCross;
            this.Password2RedCross.InitialImage = ((System.Drawing.Image)(resources.GetObject("Password2RedCross.InitialImage")));
            this.Password2RedCross.Location = new System.Drawing.Point(308, 138);
            this.Password2RedCross.Margin = new System.Windows.Forms.Padding(2);
            this.Password2RedCross.Name = "Password2RedCross";
            this.Password2RedCross.Size = new System.Drawing.Size(18, 17);
            this.Password2RedCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Password2RedCross.TabIndex = 29;
            this.Password2RedCross.TabStop = false;
            this.Password2RedCross.Visible = false;
            // 
            // Password2GreenTick
            // 
            this.Password2GreenTick.Image = global::Winform_Client.Properties.Resources.GreenTick;
            this.Password2GreenTick.InitialImage = ((System.Drawing.Image)(resources.GetObject("Password2GreenTick.InitialImage")));
            this.Password2GreenTick.Location = new System.Drawing.Point(308, 132);
            this.Password2GreenTick.Margin = new System.Windows.Forms.Padding(2);
            this.Password2GreenTick.Name = "Password2GreenTick";
            this.Password2GreenTick.Size = new System.Drawing.Size(29, 29);
            this.Password2GreenTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Password2GreenTick.TabIndex = 28;
            this.Password2GreenTick.TabStop = false;
            this.Password2GreenTick.Visible = false;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(44, 173);
            this.Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(61, 29);
            this.Cancel.TabIndex = 22;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // RenewButton
            // 
            this.RenewButton.Enabled = false;
            this.RenewButton.Location = new System.Drawing.Point(241, 173);
            this.RenewButton.Margin = new System.Windows.Forms.Padding(2);
            this.RenewButton.Name = "RenewButton";
            this.RenewButton.Size = new System.Drawing.Size(63, 29);
            this.RenewButton.TabIndex = 21;
            this.RenewButton.Text = "Renew";
            this.RenewButton.UseVisualStyleBackColor = true;
            this.RenewButton.Click += new System.EventHandler(this.RenewButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Confirm your password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Enter new password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Re enter old password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PasswordBox2
            // 
            this.PasswordBox2.Location = new System.Drawing.Point(175, 138);
            this.PasswordBox2.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordBox2.Name = "PasswordBox2";
            this.PasswordBox2.PasswordChar = '*';
            this.PasswordBox2.Size = new System.Drawing.Size(130, 20);
            this.PasswordBox2.TabIndex = 20;
            this.PasswordBox2.TextChanged += new System.EventHandler(this.PasswordBox2_TextChanged);
            // 
            // PreviousPassword
            // 
            this.PreviousPassword.Location = new System.Drawing.Point(175, 34);
            this.PreviousPassword.Margin = new System.Windows.Forms.Padding(2);
            this.PreviousPassword.Name = "PreviousPassword";
            this.PreviousPassword.PasswordChar = '*';
            this.PreviousPassword.Size = new System.Drawing.Size(130, 20);
            this.PreviousPassword.TabIndex = 17;
            this.PreviousPassword.TextChanged += new System.EventHandler(this.PreviousPassword_TextChanged);
            // 
            // PasswordBox1
            // 
            this.PasswordBox1.Location = new System.Drawing.Point(175, 103);
            this.PasswordBox1.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordBox1.Name = "PasswordBox1";
            this.PasswordBox1.PasswordChar = '*';
            this.PasswordBox1.Size = new System.Drawing.Size(130, 20);
            this.PasswordBox1.TabIndex = 19;
            this.PasswordBox1.TextChanged += new System.EventHandler(this.PasswordBox1_TextChanged);
            // 
            // IncorrectPasswordLabel
            // 
            this.IncorrectPasswordLabel.AutoSize = true;
            this.IncorrectPasswordLabel.ForeColor = System.Drawing.Color.Crimson;
            this.IncorrectPasswordLabel.Location = new System.Drawing.Point(172, 56);
            this.IncorrectPasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IncorrectPasswordLabel.Name = "IncorrectPasswordLabel";
            this.IncorrectPasswordLabel.Size = new System.Drawing.Size(97, 13);
            this.IncorrectPasswordLabel.TabIndex = 32;
            this.IncorrectPasswordLabel.Text = "Incorrect password";
            this.IncorrectPasswordLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.IncorrectPasswordLabel.Visible = false;
            // 
            // RenewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 273);
            this.Controls.Add(this.IncorrectPasswordLabel);
            this.Controls.Add(this.Password1RedCross);
            this.Controls.Add(this.Password1GreenTick);
            this.Controls.Add(this.Password2RedCross);
            this.Controls.Add(this.Password2GreenTick);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.RenewButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox2);
            this.Controls.Add(this.PreviousPassword);
            this.Controls.Add(this.PasswordBox1);
            this.Name = "RenewPassword";
            this.Text = "RenewPassword";
            ((System.ComponentModel.ISupportInitialize)(this.Password1RedCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password1GreenTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password2RedCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password2GreenTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Password1RedCross;
        private System.Windows.Forms.PictureBox Password1GreenTick;
        private System.Windows.Forms.PictureBox Password2RedCross;
        private System.Windows.Forms.PictureBox Password2GreenTick;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button RenewButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordBox2;
        private System.Windows.Forms.TextBox PreviousPassword;
        private System.Windows.Forms.TextBox PasswordBox1;
        private System.Windows.Forms.Label IncorrectPasswordLabel;
    }
}