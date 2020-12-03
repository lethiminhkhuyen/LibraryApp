using System.Windows.Forms;

namespace LibraryApp
{
    partial class LibrarianView
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
            this.components = new System.ComponentModel.Container();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.SalaryTextbox = new System.Windows.Forms.TextBox();
            this.SalaryLabel = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.BirthdayTextbox = new System.Windows.Forms.TextBox();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.LibraryFunctionsPanel = new System.Windows.Forms.Panel();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.GenreCombobox = new System.Windows.Forms.ComboBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.TitleRadioButton = new System.Windows.Forms.RadioButton();
            this.AuthorRadioButton = new System.Windows.Forms.RadioButton();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextbox = new System.Windows.Forms.TextBox();
            this.LibraryIndexLabel = new System.Windows.Forms.Label();
            this.ItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddressTextbox = new System.Windows.Forms.TextBox();
            this.LibraryMainPanel = new System.Windows.Forms.Panel();
            this.LibraryTitlePanel = new System.Windows.Forms.Panel();
            this.UserTitlePanel = new System.Windows.Forms.Panel();
            this.UserNameTextbox = new System.Windows.Forms.TextBox();
            this.UserAccountDetailsPanel = new System.Windows.Forms.Panel();
            this.AllLibrarianButton = new System.Windows.Forms.Button();
            this.AllPatronButton = new System.Windows.Forms.Button();
            this.NewBookButton = new System.Windows.Forms.Button();
            this.NewLibrarianButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.UserPersonalDetailsPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PatronContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frozeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateFineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paidFineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLibrarianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnotherCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LibraryFunctionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
            this.LibraryMainPanel.SuspendLayout();
            this.LibraryTitlePanel.SuspendLayout();
            this.UserTitlePanel.SuspendLayout();
            this.UserAccountDetailsPanel.SuspendLayout();
            this.UserPersonalDetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PatronContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddressLabel
            // 
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLabel.Location = new System.Drawing.Point(0, 300);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(400, 27);
            this.AddressLabel.TabIndex = 7;
            this.AddressLabel.Text = "Address:";
            this.AddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SalaryTextbox
            // 
            this.SalaryTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SalaryTextbox.Enabled = false;
            this.SalaryTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryTextbox.Location = new System.Drawing.Point(0, 240);
            this.SalaryTextbox.Name = "SalaryTextbox";
            this.SalaryTextbox.ReadOnly = true;
            this.SalaryTextbox.Size = new System.Drawing.Size(400, 31);
            this.SalaryTextbox.TabIndex = 6;
            this.SalaryTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SalaryLabel
            // 
            this.SalaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryLabel.Location = new System.Drawing.Point(0, 200);
            this.SalaryLabel.Name = "SalaryLabel";
            this.SalaryLabel.Size = new System.Drawing.Size(400, 30);
            this.SalaryLabel.TabIndex = 5;
            this.SalaryLabel.Text = "Salary:";
            this.SalaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTextbox.Enabled = false;
            this.EmailTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.Location = new System.Drawing.Point(0, 140);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.ReadOnly = true;
            this.EmailTextbox.Size = new System.Drawing.Size(400, 31);
            this.EmailTextbox.TabIndex = 4;
            this.EmailTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EmailLabel
            // 
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(0, 100);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(400, 27);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Email:";
            this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BirthdayTextbox
            // 
            this.BirthdayTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BirthdayTextbox.Enabled = false;
            this.BirthdayTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthdayTextbox.Location = new System.Drawing.Point(0, 40);
            this.BirthdayTextbox.Name = "BirthdayTextbox";
            this.BirthdayTextbox.ReadOnly = true;
            this.BirthdayTextbox.Size = new System.Drawing.Size(400, 31);
            this.BirthdayTextbox.TabIndex = 2;
            this.BirthdayTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BirthdayLabel.Location = new System.Drawing.Point(0, 0);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.Size = new System.Drawing.Size(400, 31);
            this.BirthdayLabel.TabIndex = 1;
            this.BirthdayLabel.Text = "Birthday:";
            this.BirthdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LibraryFunctionsPanel
            // 
            this.LibraryFunctionsPanel.Controls.Add(this.CategoryComboBox);
            this.LibraryFunctionsPanel.Controls.Add(this.CategoryLabel);
            this.LibraryFunctionsPanel.Controls.Add(this.GenreCombobox);
            this.LibraryFunctionsPanel.Controls.Add(this.GenreLabel);
            this.LibraryFunctionsPanel.Controls.Add(this.TitleRadioButton);
            this.LibraryFunctionsPanel.Controls.Add(this.AuthorRadioButton);
            this.LibraryFunctionsPanel.Controls.Add(this.SearchButton);
            this.LibraryFunctionsPanel.Controls.Add(this.SearchTextbox);
            this.LibraryFunctionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LibraryFunctionsPanel.Location = new System.Drawing.Point(0, 720);
            this.LibraryFunctionsPanel.Name = "LibraryFunctionsPanel";
            this.LibraryFunctionsPanel.Size = new System.Drawing.Size(1164, 209);
            this.LibraryFunctionsPanel.TabIndex = 2;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(675, 100);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(300, 39);
            this.CategoryComboBox.TabIndex = 6;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryLabel.Location = new System.Drawing.Point(995, 103);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(125, 31);
            this.CategoryLabel.TabIndex = 5;
            this.CategoryLabel.Text = "Category";
            // 
            // GenreCombobox
            // 
            this.GenreCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreCombobox.FormattingEnabled = true;
            this.GenreCombobox.Location = new System.Drawing.Point(50, 100);
            this.GenreCombobox.Name = "GenreCombobox";
            this.GenreCombobox.Size = new System.Drawing.Size(500, 39);
            this.GenreCombobox.TabIndex = 4;
            this.GenreCombobox.SelectedIndexChanged += new System.EventHandler(this.GenreCombobox_SelectedIndexChanged);
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreLabel.Location = new System.Drawing.Point(570, 103);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(89, 31);
            this.GenreLabel.TabIndex = 3;
            this.GenreLabel.Text = "Genre";
            // 
            // TitleRadioButton
            // 
            this.TitleRadioButton.AutoSize = true;
            this.TitleRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleRadioButton.Location = new System.Drawing.Point(230, 27);
            this.TitleRadioButton.Name = "TitleRadioButton";
            this.TitleRadioButton.Size = new System.Drawing.Size(97, 35);
            this.TitleRadioButton.TabIndex = 2;
            this.TitleRadioButton.TabStop = true;
            this.TitleRadioButton.Text = "Title";
            this.TitleRadioButton.UseVisualStyleBackColor = true;
            // 
            // AuthorRadioButton
            // 
            this.AuthorRadioButton.AutoSize = true;
            this.AuthorRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorRadioButton.Location = new System.Drawing.Point(50, 27);
            this.AuthorRadioButton.Name = "AuthorRadioButton";
            this.AuthorRadioButton.Size = new System.Drawing.Size(125, 35);
            this.AuthorRadioButton.TabIndex = 1;
            this.AuthorRadioButton.TabStop = true;
            this.AuthorRadioButton.Text = "Author";
            this.AuthorRadioButton.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(925, 20);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(200, 50);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextbox
            // 
            this.SearchTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextbox.Location = new System.Drawing.Point(380, 27);
            this.SearchTextbox.Name = "SearchTextbox";
            this.SearchTextbox.Size = new System.Drawing.Size(500, 38);
            this.SearchTextbox.TabIndex = 0;
            // 
            // LibraryIndexLabel
            // 
            this.LibraryIndexLabel.CausesValidation = false;
            this.LibraryIndexLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LibraryIndexLabel.Enabled = false;
            this.LibraryIndexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LibraryIndexLabel.Location = new System.Drawing.Point(0, 0);
            this.LibraryIndexLabel.Name = "LibraryIndexLabel";
            this.LibraryIndexLabel.Size = new System.Drawing.Size(1164, 76);
            this.LibraryIndexLabel.TabIndex = 0;
            this.LibraryIndexLabel.Text = "Library Index";
            this.LibraryIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemsDataGridView
            // 
            this.ItemsDataGridView.AllowUserToAddRows = false;
            this.ItemsDataGridView.AllowUserToDeleteRows = false;
            this.ItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ItemsDataGridView.Name = "ItemsDataGridView";
            this.ItemsDataGridView.RowTemplate.Height = 33;
            this.ItemsDataGridView.Size = new System.Drawing.Size(1164, 638);
            this.ItemsDataGridView.TabIndex = 0;
            // 
            // AddressTextbox
            // 
            this.AddressTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddressTextbox.Enabled = false;
            this.AddressTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTextbox.Location = new System.Drawing.Point(0, 340);
            this.AddressTextbox.Multiline = true;
            this.AddressTextbox.Name = "AddressTextbox";
            this.AddressTextbox.ReadOnly = true;
            this.AddressTextbox.Size = new System.Drawing.Size(400, 100);
            this.AddressTextbox.TabIndex = 8;
            this.AddressTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LibraryMainPanel
            // 
            this.LibraryMainPanel.Controls.Add(this.ItemsDataGridView);
            this.LibraryMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LibraryMainPanel.Location = new System.Drawing.Point(0, 76);
            this.LibraryMainPanel.Name = "LibraryMainPanel";
            this.LibraryMainPanel.Size = new System.Drawing.Size(1164, 853);
            this.LibraryMainPanel.TabIndex = 1;
            // 
            // LibraryTitlePanel
            // 
            this.LibraryTitlePanel.Controls.Add(this.LibraryIndexLabel);
            this.LibraryTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LibraryTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.LibraryTitlePanel.Name = "LibraryTitlePanel";
            this.LibraryTitlePanel.Size = new System.Drawing.Size(1164, 76);
            this.LibraryTitlePanel.TabIndex = 0;
            // 
            // UserTitlePanel
            // 
            this.UserTitlePanel.Controls.Add(this.UserNameTextbox);
            this.UserTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.UserTitlePanel.Name = "UserTitlePanel";
            this.UserTitlePanel.Size = new System.Drawing.Size(406, 100);
            this.UserTitlePanel.TabIndex = 0;
            // 
            // UserNameTextbox
            // 
            this.UserNameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserNameTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UserNameTextbox.Enabled = false;
            this.UserNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextbox.Location = new System.Drawing.Point(0, 20);
            this.UserNameTextbox.Multiline = true;
            this.UserNameTextbox.Name = "UserNameTextbox";
            this.UserNameTextbox.ReadOnly = true;
            this.UserNameTextbox.Size = new System.Drawing.Size(400, 70);
            this.UserNameTextbox.TabIndex = 0;
            this.UserNameTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserAccountDetailsPanel
            // 
            this.UserAccountDetailsPanel.Controls.Add(this.AllLibrarianButton);
            this.UserAccountDetailsPanel.Controls.Add(this.AllPatronButton);
            this.UserAccountDetailsPanel.Controls.Add(this.NewBookButton);
            this.UserAccountDetailsPanel.Controls.Add(this.NewLibrarianButton);
            this.UserAccountDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserAccountDetailsPanel.Location = new System.Drawing.Point(0, 100);
            this.UserAccountDetailsPanel.Name = "UserAccountDetailsPanel";
            this.UserAccountDetailsPanel.Size = new System.Drawing.Size(406, 829);
            this.UserAccountDetailsPanel.TabIndex = 1;
            // 
            // AllLibrarianButton
            // 
            this.AllLibrarianButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllLibrarianButton.Location = new System.Drawing.Point(50, 190);
            this.AllLibrarianButton.Name = "AllLibrarianButton";
            this.AllLibrarianButton.Size = new System.Drawing.Size(300, 50);
            this.AllLibrarianButton.TabIndex = 3;
            this.AllLibrarianButton.Text = "View All Librarian";
            this.AllLibrarianButton.UseVisualStyleBackColor = true;
            this.AllLibrarianButton.Click += new System.EventHandler(this.AllLibrarianButton_Click);
            // 
            // AllPatronButton
            // 
            this.AllPatronButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllPatronButton.Location = new System.Drawing.Point(50, 130);
            this.AllPatronButton.Name = "AllPatronButton";
            this.AllPatronButton.Size = new System.Drawing.Size(300, 50);
            this.AllPatronButton.TabIndex = 2;
            this.AllPatronButton.Text = "View All Patrons";
            this.AllPatronButton.UseVisualStyleBackColor = true;
            this.AllPatronButton.Click += new System.EventHandler(this.AllPatronButton_Click);
            // 
            // NewBookButton
            // 
            this.NewBookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBookButton.Location = new System.Drawing.Point(50, 70);
            this.NewBookButton.Name = "NewBookButton";
            this.NewBookButton.Size = new System.Drawing.Size(300, 50);
            this.NewBookButton.TabIndex = 1;
            this.NewBookButton.Text = "Add New Book";
            this.NewBookButton.UseVisualStyleBackColor = true;
            this.NewBookButton.Click += new System.EventHandler(this.NewBookButton_Click);
            // 
            // NewLibrarianButton
            // 
            this.NewLibrarianButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewLibrarianButton.Location = new System.Drawing.Point(50, 10);
            this.NewLibrarianButton.Name = "NewLibrarianButton";
            this.NewLibrarianButton.Size = new System.Drawing.Size(300, 50);
            this.NewLibrarianButton.TabIndex = 0;
            this.NewLibrarianButton.Text = "Add New Librarian";
            this.NewLibrarianButton.UseVisualStyleBackColor = true;
            this.NewLibrarianButton.Click += new System.EventHandler(this.NewLibrarianButton_Click);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyButton.Location = new System.Drawing.Point(100, 460);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(200, 50);
            this.ModifyButton.TabIndex = 0;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // UserPersonalDetailsPanel
            // 
            this.UserPersonalDetailsPanel.Controls.Add(this.AddressTextbox);
            this.UserPersonalDetailsPanel.Controls.Add(this.AddressLabel);
            this.UserPersonalDetailsPanel.Controls.Add(this.SalaryTextbox);
            this.UserPersonalDetailsPanel.Controls.Add(this.SalaryLabel);
            this.UserPersonalDetailsPanel.Controls.Add(this.EmailTextbox);
            this.UserPersonalDetailsPanel.Controls.Add(this.EmailLabel);
            this.UserPersonalDetailsPanel.Controls.Add(this.BirthdayTextbox);
            this.UserPersonalDetailsPanel.Controls.Add(this.BirthdayLabel);
            this.UserPersonalDetailsPanel.Controls.Add(this.ModifyButton);
            this.UserPersonalDetailsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserPersonalDetailsPanel.Location = new System.Drawing.Point(0, 354);
            this.UserPersonalDetailsPanel.Name = "UserPersonalDetailsPanel";
            this.UserPersonalDetailsPanel.Size = new System.Drawing.Size(406, 575);
            this.UserPersonalDetailsPanel.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.UserPersonalDetailsPanel);
            this.splitContainer1.Panel1.Controls.Add(this.UserAccountDetailsPanel);
            this.splitContainer1.Panel1.Controls.Add(this.UserTitlePanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LibraryFunctionsPanel);
            this.splitContainer1.Panel2.Controls.Add(this.LibraryMainPanel);
            this.splitContainer1.Panel2.Controls.Add(this.LibraryTitlePanel);
            this.splitContainer1.Size = new System.Drawing.Size(1574, 929);
            this.splitContainer1.SplitterDistance = 406;
            this.splitContainer1.TabIndex = 1;
            // 
            // PatronContextMenuStrip
            // 
            this.PatronContextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.PatronContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeAccountToolStripMenuItem,
            this.frozeAccountToolStripMenuItem,
            this.closeAccountToolStripMenuItem,
            this.calculateFineToolStripMenuItem,
            this.paidFineToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.removeItemToolStripMenuItem,
            this.removeLibrarianToolStripMenuItem,
            this.addAnotherCopyToolStripMenuItem});
            this.PatronContextMenuStrip.Name = "PatronContextMenuStrip1";
            this.PatronContextMenuStrip.Size = new System.Drawing.Size(301, 372);
            // 
            // activeAccountToolStripMenuItem
            // 
            this.activeAccountToolStripMenuItem.Name = "activeAccountToolStripMenuItem";
            this.activeAccountToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.activeAccountToolStripMenuItem.Text = "Active Account";
            this.activeAccountToolStripMenuItem.Click += new System.EventHandler(this.activeAccountToolStripMenuItem_Click);
            // 
            // frozeAccountToolStripMenuItem
            // 
            this.frozeAccountToolStripMenuItem.Name = "frozeAccountToolStripMenuItem";
            this.frozeAccountToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.frozeAccountToolStripMenuItem.Text = "Froze Account";
            this.frozeAccountToolStripMenuItem.Click += new System.EventHandler(this.frozeAccountToolStripMenuItem_Click);
            // 
            // closeAccountToolStripMenuItem
            // 
            this.closeAccountToolStripMenuItem.Name = "closeAccountToolStripMenuItem";
            this.closeAccountToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.closeAccountToolStripMenuItem.Text = "Close Account";
            this.closeAccountToolStripMenuItem.Click += new System.EventHandler(this.closeAccountToolStripMenuItem_Click);
            // 
            // calculateFineToolStripMenuItem
            // 
            this.calculateFineToolStripMenuItem.Name = "calculateFineToolStripMenuItem";
            this.calculateFineToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.calculateFineToolStripMenuItem.Text = "Calculate Fine";
            this.calculateFineToolStripMenuItem.Click += new System.EventHandler(this.calculateFineToolStripMenuItem_Click);
            // 
            // paidFineToolStripMenuItem
            // 
            this.paidFineToolStripMenuItem.Name = "paidFineToolStripMenuItem";
            this.paidFineToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.paidFineToolStripMenuItem.Text = "Paid Fine";
            this.paidFineToolStripMenuItem.Click += new System.EventHandler(this.paidFineToolStripMenuItem_Click);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.editItemToolStripMenuItem.Text = "Edit Item";
            this.editItemToolStripMenuItem.Click += new System.EventHandler(this.editItemToolStripMenuItem_Click);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.removeItemToolStripMenuItem.Text = "Remove Item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.removeItemToolStripMenuItem_Click);
            // 
            // removeLibrarianToolStripMenuItem
            // 
            this.removeLibrarianToolStripMenuItem.Name = "removeLibrarianToolStripMenuItem";
            this.removeLibrarianToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.removeLibrarianToolStripMenuItem.Text = "Remove Librarian";
            this.removeLibrarianToolStripMenuItem.Click += new System.EventHandler(this.removeLibrarianToolStripMenuItem_Click);
            // 
            // addAnotherCopyToolStripMenuItem
            // 
            this.addAnotherCopyToolStripMenuItem.Name = "addAnotherCopyToolStripMenuItem";
            this.addAnotherCopyToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
            this.addAnotherCopyToolStripMenuItem.Text = "Add Another Copy";
            this.addAnotherCopyToolStripMenuItem.Click += new System.EventHandler(this.addAnotherCopyToolStripMenuItem_Click);
            // 
            // LibrarianView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 929);
            this.ContextMenuStrip = this.PatronContextMenuStrip;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1600, 1000);
            this.MinimumSize = new System.Drawing.Size(1600, 1000);
            this.Name = "LibrarianView";
            this.Text = "LibrarianView";
            this.LibraryFunctionsPanel.ResumeLayout(false);
            this.LibraryFunctionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
            this.LibraryMainPanel.ResumeLayout(false);
            this.LibraryTitlePanel.ResumeLayout(false);
            this.UserTitlePanel.ResumeLayout(false);
            this.UserTitlePanel.PerformLayout();
            this.UserAccountDetailsPanel.ResumeLayout(false);
            this.UserPersonalDetailsPanel.ResumeLayout(false);
            this.UserPersonalDetailsPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PatronContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox SalaryTextbox;
        private System.Windows.Forms.Label SalaryLabel;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox BirthdayTextbox;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Panel LibraryFunctionsPanel;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.ComboBox GenreCombobox;
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.RadioButton TitleRadioButton;
        private System.Windows.Forms.RadioButton AuthorRadioButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextbox;
        private System.Windows.Forms.Label LibraryIndexLabel;
        private System.Windows.Forms.DataGridView ItemsDataGridView;
        private System.Windows.Forms.TextBox AddressTextbox;
        private System.Windows.Forms.Panel LibraryMainPanel;
        private System.Windows.Forms.Panel LibraryTitlePanel;
        private System.Windows.Forms.Panel UserTitlePanel;
        private System.Windows.Forms.TextBox UserNameTextbox;
        private System.Windows.Forms.Panel UserAccountDetailsPanel;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.Panel UserPersonalDetailsPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button NewBookButton;
        private System.Windows.Forms.Button NewLibrarianButton;
        private System.Windows.Forms.Button AllLibrarianButton;
        private System.Windows.Forms.Button AllPatronButton;
        private ContextMenuStrip PatronContextMenuStrip;
        private ToolStripMenuItem activeAccountToolStripMenuItem;
        private ToolStripMenuItem frozeAccountToolStripMenuItem;
        private ToolStripMenuItem closeAccountToolStripMenuItem;
        private ToolStripMenuItem calculateFineToolStripMenuItem;
        private ToolStripMenuItem paidFineToolStripMenuItem;
        private ToolStripMenuItem editItemToolStripMenuItem;
        private ToolStripMenuItem removeItemToolStripMenuItem;
        private ToolStripMenuItem removeLibrarianToolStripMenuItem;
        private ToolStripMenuItem addAnotherCopyToolStripMenuItem;
    }
}