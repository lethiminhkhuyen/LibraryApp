namespace LibraryApp
{
    partial class LogInForm
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
            this.UserLoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.useLoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.warningText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserLoginTextBox
            // 
            this.UserLoginTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserLoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserLoginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLoginTextBox.Location = new System.Drawing.Point(340, 107);
            this.UserLoginTextBox.Name = "UserLoginTextBox";
            this.UserLoginTextBox.Size = new System.Drawing.Size(400, 38);
            this.UserLoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(340, 197);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(400, 38);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // useLoginLabel
            // 
            this.useLoginLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.useLoginLabel.AutoSize = true;
            this.useLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useLoginLabel.ForeColor = System.Drawing.Color.Black;
            this.useLoginLabel.Location = new System.Drawing.Point(120, 110);
            this.useLoginLabel.Name = "useLoginLabel";
            this.useLoginLabel.Size = new System.Drawing.Size(145, 31);
            this.useLoginLabel.TabIndex = 2;
            this.useLoginLabel.Text = "User Login";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(120, 200);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(134, 31);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // logInButton
            // 
            this.logInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInButton.Location = new System.Drawing.Point(540, 285);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(200, 50);
            this.logInButton.TabIndex = 4;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // warningText
            // 
            this.warningText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.warningText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningText.ForeColor = System.Drawing.Color.DodgerBlue;
            this.warningText.Location = new System.Drawing.Point(100, 400);
            this.warningText.Name = "warningText";
            this.warningText.ReadOnly = true;
            this.warningText.Size = new System.Drawing.Size(700, 24);
            this.warningText.TabIndex = 5;
            this.warningText.Text = "Something is wrong, please check your details and log in again.";
            this.warningText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 529);
            this.Controls.Add(this.warningText);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.useLoginLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserLoginTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserLoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label useLoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.TextBox warningText;
    }
}