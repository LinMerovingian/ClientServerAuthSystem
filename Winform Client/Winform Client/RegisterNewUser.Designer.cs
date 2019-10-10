namespace Winform_Client
{
    partial class RegisterNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterNewUser));
            this.PasswordBox1 = new System.Windows.Forms.TextBox();
            this.UserNameChoice = new System.Windows.Forms.TextBox();
            this.PasswordBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.CheckNameAvailabilityButton = new System.Windows.Forms.Button();
            this.UserNameRedCross = new System.Windows.Forms.PictureBox();
            this.UserNameGreenTick = new System.Windows.Forms.PictureBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.PasswordRedCross = new System.Windows.Forms.PictureBox();
            this.PasswordGreenTick = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameRedCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameGreenTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordRedCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordGreenTick)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordBox1
            // 
            this.PasswordBox1.Location = new System.Drawing.Point(176, 103);
            this.PasswordBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordBox1.Name = "PasswordBox1";
            this.PasswordBox1.PasswordChar = '*';
            this.PasswordBox1.Size = new System.Drawing.Size(130, 20);
            this.PasswordBox1.TabIndex = 3;
            this.PasswordBox1.TextChanged += new System.EventHandler(this.PasswordBox1_TextChanged);
            // 
            // UserNameChoice
            // 
            this.UserNameChoice.Location = new System.Drawing.Point(176, 34);
            this.UserNameChoice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserNameChoice.Name = "UserNameChoice";
            this.UserNameChoice.Size = new System.Drawing.Size(130, 20);
            this.UserNameChoice.TabIndex = 1;
            this.UserNameChoice.TextChanged += new System.EventHandler(this.UserNameChoice_TextChanged);
            // 
            // PasswordBox2
            // 
            this.PasswordBox2.Location = new System.Drawing.Point(176, 138);
            this.PasswordBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordBox2.Name = "PasswordBox2";
            this.PasswordBox2.PasswordChar = '*';
            this.PasswordBox2.Size = new System.Drawing.Size(130, 20);
            this.PasswordBox2.TabIndex = 4;
            this.PasswordBox2.TextChanged += new System.EventHandler(this.PasswordBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Choose a username\r\n(single word)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Create a password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm your password";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Enabled = false;
            this.RegisterButton.Location = new System.Drawing.Point(242, 173);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(63, 20);
            this.RegisterButton.TabIndex = 5;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // CheckNameAvailabilityButton
            // 
            this.CheckNameAvailabilityButton.Location = new System.Drawing.Point(203, 67);
            this.CheckNameAvailabilityButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckNameAvailabilityButton.Name = "CheckNameAvailabilityButton";
            this.CheckNameAvailabilityButton.Size = new System.Drawing.Size(101, 22);
            this.CheckNameAvailabilityButton.TabIndex = 2;
            this.CheckNameAvailabilityButton.Text = "Check availability";
            this.CheckNameAvailabilityButton.UseVisualStyleBackColor = true;
            this.CheckNameAvailabilityButton.Click += new System.EventHandler(this.CheckNameAvailabilityButton_Click);
            // 
            // UserNameRedCross
            // 
            this.UserNameRedCross.Image = global::Winform_Client.Properties.Resources.RedCross;
            this.UserNameRedCross.InitialImage = ((System.Drawing.Image)(resources.GetObject("UserNameRedCross.InitialImage")));
            this.UserNameRedCross.Location = new System.Drawing.Point(309, 34);
            this.UserNameRedCross.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserNameRedCross.Name = "UserNameRedCross";
            this.UserNameRedCross.Size = new System.Drawing.Size(18, 17);
            this.UserNameRedCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserNameRedCross.TabIndex = 9;
            this.UserNameRedCross.TabStop = false;
            this.UserNameRedCross.Visible = false;
            // 
            // UserNameGreenTick
            // 
            this.UserNameGreenTick.Image = global::Winform_Client.Properties.Resources.GreenTick;
            this.UserNameGreenTick.InitialImage = ((System.Drawing.Image)(resources.GetObject("UserNameGreenTick.InitialImage")));
            this.UserNameGreenTick.Location = new System.Drawing.Point(309, 28);
            this.UserNameGreenTick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserNameGreenTick.Name = "UserNameGreenTick";
            this.UserNameGreenTick.Size = new System.Drawing.Size(29, 29);
            this.UserNameGreenTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserNameGreenTick.TabIndex = 8;
            this.UserNameGreenTick.TabStop = false;
            this.UserNameGreenTick.Visible = false;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(45, 173);
            this.Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(61, 20);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // PasswordRedCross
            // 
            this.PasswordRedCross.Image = global::Winform_Client.Properties.Resources.RedCross;
            this.PasswordRedCross.InitialImage = ((System.Drawing.Image)(resources.GetObject("PasswordRedCross.InitialImage")));
            this.PasswordRedCross.Location = new System.Drawing.Point(309, 138);
            this.PasswordRedCross.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordRedCross.Name = "PasswordRedCross";
            this.PasswordRedCross.Size = new System.Drawing.Size(18, 17);
            this.PasswordRedCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PasswordRedCross.TabIndex = 14;
            this.PasswordRedCross.TabStop = false;
            this.PasswordRedCross.Visible = false;
            // 
            // PasswordGreenTick
            // 
            this.PasswordGreenTick.Image = global::Winform_Client.Properties.Resources.GreenTick;
            this.PasswordGreenTick.InitialImage = ((System.Drawing.Image)(resources.GetObject("PasswordGreenTick.InitialImage")));
            this.PasswordGreenTick.Location = new System.Drawing.Point(309, 132);
            this.PasswordGreenTick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordGreenTick.Name = "PasswordGreenTick";
            this.PasswordGreenTick.Size = new System.Drawing.Size(29, 29);
            this.PasswordGreenTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PasswordGreenTick.TabIndex = 13;
            this.PasswordGreenTick.TabStop = false;
            this.PasswordGreenTick.Visible = false;
            // 
            // RegisterNewUser
            // 
            this.AcceptButton = this.RegisterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 241);
            this.Controls.Add(this.PasswordRedCross);
            this.Controls.Add(this.PasswordGreenTick);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.UserNameRedCross);
            this.Controls.Add(this.UserNameGreenTick);
            this.Controls.Add(this.CheckNameAvailabilityButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordBox2);
            this.Controls.Add(this.UserNameChoice);
            this.Controls.Add(this.PasswordBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegisterNewUser";
            this.Text = "Register new user";
            ((System.ComponentModel.ISupportInitialize)(this.UserNameRedCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameGreenTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordRedCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordGreenTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameChoice;
        private System.Windows.Forms.Button CheckNameAvailabilityButton;
        private System.Windows.Forms.TextBox PasswordBox1;
        private System.Windows.Forms.TextBox PasswordBox2;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox UserNameGreenTick;
        private System.Windows.Forms.PictureBox UserNameRedCross;
        private System.Windows.Forms.PictureBox PasswordRedCross;
        private System.Windows.Forms.PictureBox PasswordGreenTick;
    }
}