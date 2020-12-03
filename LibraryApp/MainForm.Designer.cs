namespace LibraryApp
{
    partial class MainForm
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
            this.tekstPowitalny = new System.Windows.Forms.TextBox();
            this.logInButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tekstPowitalny
            // 
            this.tekstPowitalny.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tekstPowitalny.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tekstPowitalny.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tekstPowitalny.Enabled = false;
            this.tekstPowitalny.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tekstPowitalny.Location = new System.Drawing.Point(200, 100);
            this.tekstPowitalny.Multiline = true;
            this.tekstPowitalny.Name = "tekstPowitalny";
            this.tekstPowitalny.ReadOnly = true;
            this.tekstPowitalny.Size = new System.Drawing.Size(500, 71);
            this.tekstPowitalny.TabIndex = 0;
            this.tekstPowitalny.Text = "WELCOME! PLEASE REGISTER IF YOU HAVEN\'T DONE IT YET.";
            this.tekstPowitalny.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logInButton
            // 
            this.logInButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logInButton.AutoSize = true;
            this.logInButton.Location = new System.Drawing.Point(200, 300);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(200, 50);
            this.logInButton.TabIndex = 1;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.AutoSize = true;
            this.registerButton.Location = new System.Drawing.Point(500, 300);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(200, 50);
            this.registerButton.TabIndex = 2;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 529);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.tekstPowitalny);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Powitanie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tekstPowitalny;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Button registerButton;
    }
}