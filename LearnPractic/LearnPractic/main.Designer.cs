namespace LearnPractic
{
    partial class main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageEmployee = new System.Windows.Forms.TabPage();
            this.buttonClear = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPost = new System.Windows.Forms.ComboBox();
            this.textBoxSalary = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageSklad = new System.Windows.Forms.TabPage();
            this.tabPageCash = new System.Windows.Forms.TabPage();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.UDQuantity = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewSklad = new System.Windows.Forms.DataGridView();
            this.textBoxDrugName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TextBoxComposits = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TextBoxRecipe = new System.Windows.Forms.RichTextBox();
            this.buttonDrugDelete = new System.Windows.Forms.Button();
            this.buttonDrugChange = new System.Windows.Forms.Button();
            this.buttonDrugAdd = new System.Windows.Forms.Button();
            this.buttonDrugClear = new System.Windows.Forms.Button();
            this.comboBoxDrugNameToCart = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.UDQuantityDrugToCart = new System.Windows.Forms.NumericUpDown();
            this.labelSumToCart = new System.Windows.Forms.Label();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.buttonClearFormCart = new System.Windows.Forms.Button();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.buttonBuyCart = new System.Windows.Forms.Button();
            this.labelAllSumCart = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.tabPageSklad.SuspendLayout();
            this.tabPageCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UDQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSklad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDQuantityDrugToCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageEmployee);
            this.tabControl1.Controls.Add(this.tabPageSklad);
            this.tabControl1.Controls.Add(this.tabPageCash);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1238, 506);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPageEmployee
            // 
            this.tabPageEmployee.Controls.Add(this.buttonClear);
            this.tabPageEmployee.Controls.Add(this.dataGridViewUsers);
            this.tabPageEmployee.Controls.Add(this.buttonDelete);
            this.tabPageEmployee.Controls.Add(this.buttonChange);
            this.tabPageEmployee.Controls.Add(this.buttonAdd);
            this.tabPageEmployee.Controls.Add(this.label10);
            this.tabPageEmployee.Controls.Add(this.comboBoxPost);
            this.tabPageEmployee.Controls.Add(this.textBoxSalary);
            this.tabPageEmployee.Controls.Add(this.label9);
            this.tabPageEmployee.Controls.Add(this.textBoxAdress);
            this.tabPageEmployee.Controls.Add(this.label8);
            this.tabPageEmployee.Controls.Add(this.textBoxEmail);
            this.tabPageEmployee.Controls.Add(this.label7);
            this.tabPageEmployee.Controls.Add(this.textBoxPhone);
            this.tabPageEmployee.Controls.Add(this.label6);
            this.tabPageEmployee.Controls.Add(this.textBoxPatronymic);
            this.tabPageEmployee.Controls.Add(this.label5);
            this.tabPageEmployee.Controls.Add(this.textBoxLastName);
            this.tabPageEmployee.Controls.Add(this.label4);
            this.tabPageEmployee.Controls.Add(this.textBoxFirstName);
            this.tabPageEmployee.Controls.Add(this.label3);
            this.tabPageEmployee.Controls.Add(this.textBoxPassword);
            this.tabPageEmployee.Controls.Add(this.label2);
            this.tabPageEmployee.Controls.Add(this.textBoxLogin);
            this.tabPageEmployee.Controls.Add(this.label1);
            this.tabPageEmployee.Location = new System.Drawing.Point(4, 25);
            this.tabPageEmployee.Name = "tabPageEmployee";
            this.tabPageEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployee.Size = new System.Drawing.Size(1230, 477);
            this.tabPageEmployee.TabIndex = 0;
            this.tabPageEmployee.Text = "Сотрудники";
            this.tabPageEmployee.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(263, 46);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(83, 30);
            this.buttonClear.TabIndex = 20;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(369, 6);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.RowHeadersWidth = 51;
            this.dataGridViewUsers.RowTemplate.Height = 24;
            this.dataGridViewUsers.Size = new System.Drawing.Size(855, 465);
            this.dataGridViewUsers.TabIndex = 14;
            this.dataGridViewUsers.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_RowEnter);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(243, 342);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(103, 30);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.Location = new System.Drawing.Point(134, 342);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(103, 30);
            this.buttonChange.TabIndex = 12;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(26, 342);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(102, 30);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(193, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Post";
            // 
            // comboBoxPost
            // 
            this.comboBoxPost.FormattingEnabled = true;
            this.comboBoxPost.Location = new System.Drawing.Point(196, 302);
            this.comboBoxPost.Name = "comboBoxPost";
            this.comboBoxPost.Size = new System.Drawing.Size(150, 24);
            this.comboBoxPost.TabIndex = 10;
            // 
            // textBoxSalary
            // 
            this.textBoxSalary.Location = new System.Drawing.Point(196, 252);
            this.textBoxSalary.Name = "textBoxSalary";
            this.textBoxSalary.Size = new System.Drawing.Size(150, 22);
            this.textBoxSalary.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Salary";
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(196, 202);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(150, 22);
            this.textBoxAdress.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Adress";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(196, 152);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(150, 22);
            this.textBoxEmail.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(196, 102);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(150, 22);
            this.textBoxPhone.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Phone";
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(26, 302);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(150, 22);
            this.textBoxPatronymic.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Patronymic";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(26, 252);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(150, 22);
            this.textBoxLastName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last name";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(26, 202);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(150, 22);
            this.textBoxFirstName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "First name";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(26, 152);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(150, 22);
            this.textBoxPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(26, 102);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(150, 22);
            this.textBoxLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // tabPageSklad
            // 
            this.tabPageSklad.Controls.Add(this.buttonDrugClear);
            this.tabPageSklad.Controls.Add(this.buttonDrugDelete);
            this.tabPageSklad.Controls.Add(this.buttonDrugChange);
            this.tabPageSklad.Controls.Add(this.buttonDrugAdd);
            this.tabPageSklad.Controls.Add(this.label14);
            this.tabPageSklad.Controls.Add(this.TextBoxRecipe);
            this.tabPageSklad.Controls.Add(this.label13);
            this.tabPageSklad.Controls.Add(this.TextBoxComposits);
            this.tabPageSklad.Controls.Add(this.label12);
            this.tabPageSklad.Controls.Add(this.textBoxDrugName);
            this.tabPageSklad.Controls.Add(this.label11);
            this.tabPageSklad.Controls.Add(this.dataGridViewSklad);
            this.tabPageSklad.Controls.Add(this.UDQuantity);
            this.tabPageSklad.Location = new System.Drawing.Point(4, 25);
            this.tabPageSklad.Name = "tabPageSklad";
            this.tabPageSklad.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSklad.Size = new System.Drawing.Size(1230, 477);
            this.tabPageSklad.TabIndex = 1;
            this.tabPageSklad.Text = "Склад";
            this.tabPageSklad.UseVisualStyleBackColor = true;
            // 
            // tabPageCash
            // 
            this.tabPageCash.Controls.Add(this.labelAllSumCart);
            this.tabPageCash.Controls.Add(this.buttonBuyCart);
            this.tabPageCash.Controls.Add(this.dataGridViewCart);
            this.tabPageCash.Controls.Add(this.buttonClearFormCart);
            this.tabPageCash.Controls.Add(this.buttonAddToCart);
            this.tabPageCash.Controls.Add(this.labelSumToCart);
            this.tabPageCash.Controls.Add(this.UDQuantityDrugToCart);
            this.tabPageCash.Controls.Add(this.label16);
            this.tabPageCash.Controls.Add(this.label23);
            this.tabPageCash.Controls.Add(this.comboBoxDrugNameToCart);
            this.tabPageCash.Location = new System.Drawing.Point(4, 25);
            this.tabPageCash.Name = "tabPageCash";
            this.tabPageCash.Size = new System.Drawing.Size(1230, 477);
            this.tabPageCash.TabIndex = 2;
            this.tabPageCash.Text = "Касса";
            this.tabPageCash.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(13, 521);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(31, 17);
            this.labelInfo.TabIndex = 20;
            this.labelInfo.Text = "info";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(1171, 521);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 21;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // UDQuantity
            // 
            this.UDQuantity.Location = new System.Drawing.Point(81, 118);
            this.UDQuantity.Name = "UDQuantity";
            this.UDQuantity.Size = new System.Drawing.Size(200, 22);
            this.UDQuantity.TabIndex = 0;
            // 
            // dataGridViewSklad
            // 
            this.dataGridViewSklad.AllowUserToAddRows = false;
            this.dataGridViewSklad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSklad.Location = new System.Drawing.Point(369, 6);
            this.dataGridViewSklad.MultiSelect = false;
            this.dataGridViewSklad.Name = "dataGridViewSklad";
            this.dataGridViewSklad.ReadOnly = true;
            this.dataGridViewSklad.RowHeadersWidth = 51;
            this.dataGridViewSklad.RowTemplate.Height = 24;
            this.dataGridViewSklad.Size = new System.Drawing.Size(855, 465);
            this.dataGridViewSklad.TabIndex = 15;
            // 
            // textBoxDrugName
            // 
            this.textBoxDrugName.Location = new System.Drawing.Point(81, 68);
            this.textBoxDrugName.Name = "textBoxDrugName";
            this.textBoxDrugName.Size = new System.Drawing.Size(200, 22);
            this.textBoxDrugName.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(78, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(78, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Quantity";
            // 
            // TextBoxComposits
            // 
            this.TextBoxComposits.Location = new System.Drawing.Point(81, 168);
            this.TextBoxComposits.Name = "TextBoxComposits";
            this.TextBoxComposits.Size = new System.Drawing.Size(200, 96);
            this.TextBoxComposits.TabIndex = 19;
            this.TextBoxComposits.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(78, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "Compositions";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(78, 272);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 17);
            this.label14.TabIndex = 22;
            this.label14.Text = "Recipe";
            // 
            // TextBoxRecipe
            // 
            this.TextBoxRecipe.Location = new System.Drawing.Point(81, 292);
            this.TextBoxRecipe.Name = "TextBoxRecipe";
            this.TextBoxRecipe.Size = new System.Drawing.Size(200, 96);
            this.TextBoxRecipe.TabIndex = 21;
            this.TextBoxRecipe.Text = "";
            // 
            // buttonDrugDelete
            // 
            this.buttonDrugDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrugDelete.Location = new System.Drawing.Point(242, 403);
            this.buttonDrugDelete.Name = "buttonDrugDelete";
            this.buttonDrugDelete.Size = new System.Drawing.Size(103, 30);
            this.buttonDrugDelete.TabIndex = 25;
            this.buttonDrugDelete.Text = "Delete";
            this.buttonDrugDelete.UseVisualStyleBackColor = true;
            // 
            // buttonDrugChange
            // 
            this.buttonDrugChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrugChange.Location = new System.Drawing.Point(133, 403);
            this.buttonDrugChange.Name = "buttonDrugChange";
            this.buttonDrugChange.Size = new System.Drawing.Size(103, 30);
            this.buttonDrugChange.TabIndex = 24;
            this.buttonDrugChange.Text = "Change";
            this.buttonDrugChange.UseVisualStyleBackColor = true;
            // 
            // buttonDrugAdd
            // 
            this.buttonDrugAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrugAdd.Location = new System.Drawing.Point(25, 403);
            this.buttonDrugAdd.Name = "buttonDrugAdd";
            this.buttonDrugAdd.Size = new System.Drawing.Size(102, 30);
            this.buttonDrugAdd.TabIndex = 23;
            this.buttonDrugAdd.Text = "Add";
            this.buttonDrugAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDrugClear
            // 
            this.buttonDrugClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDrugClear.Location = new System.Drawing.Point(262, 22);
            this.buttonDrugClear.Name = "buttonDrugClear";
            this.buttonDrugClear.Size = new System.Drawing.Size(83, 30);
            this.buttonDrugClear.TabIndex = 26;
            this.buttonDrugClear.Text = "Clear";
            this.buttonDrugClear.UseVisualStyleBackColor = true;
            // 
            // comboBoxDrugNameToCart
            // 
            this.comboBoxDrugNameToCart.FormattingEnabled = true;
            this.comboBoxDrugNameToCart.Location = new System.Drawing.Point(89, 173);
            this.comboBoxDrugNameToCart.Name = "comboBoxDrugNameToCart";
            this.comboBoxDrugNameToCart.Size = new System.Drawing.Size(200, 24);
            this.comboBoxDrugNameToCart.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(86, 153);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 17);
            this.label23.TabIndex = 1;
            this.label23.Text = "Drug Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(86, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "Quantity";
            // 
            // UDQuantityDrugToCart
            // 
            this.UDQuantityDrugToCart.Location = new System.Drawing.Point(89, 223);
            this.UDQuantityDrugToCart.Name = "UDQuantityDrugToCart";
            this.UDQuantityDrugToCart.Size = new System.Drawing.Size(200, 22);
            this.UDQuantityDrugToCart.TabIndex = 3;
            // 
            // labelSumToCart
            // 
            this.labelSumToCart.AutoSize = true;
            this.labelSumToCart.Location = new System.Drawing.Point(86, 253);
            this.labelSumToCart.Name = "labelSumToCart";
            this.labelSumToCart.Size = new System.Drawing.Size(44, 17);
            this.labelSumToCart.TabIndex = 4;
            this.labelSumToCart.Text = "Sum: ";
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddToCart.Location = new System.Drawing.Point(89, 284);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(200, 30);
            this.buttonAddToCart.TabIndex = 5;
            this.buttonAddToCart.Text = "Add To Cart";
            this.buttonAddToCart.UseVisualStyleBackColor = true;
            // 
            // buttonClearFormCart
            // 
            this.buttonClearFormCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearFormCart.Location = new System.Drawing.Point(214, 103);
            this.buttonClearFormCart.Name = "buttonClearFormCart";
            this.buttonClearFormCart.Size = new System.Drawing.Size(75, 30);
            this.buttonClearFormCart.TabIndex = 6;
            this.buttonClearFormCart.Text = "Clear";
            this.buttonClearFormCart.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AllowUserToAddRows = false;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(369, 6);
            this.dataGridViewCart.MultiSelect = false;
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.RowTemplate.Height = 24;
            this.dataGridViewCart.Size = new System.Drawing.Size(855, 403);
            this.dataGridViewCart.TabIndex = 16;
            // 
            // buttonBuyCart
            // 
            this.buttonBuyCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuyCart.Location = new System.Drawing.Point(1144, 425);
            this.buttonBuyCart.Name = "buttonBuyCart";
            this.buttonBuyCart.Size = new System.Drawing.Size(80, 30);
            this.buttonBuyCart.TabIndex = 17;
            this.buttonBuyCart.Text = "Buy";
            this.buttonBuyCart.UseVisualStyleBackColor = true;
            // 
            // labelAllSumCart
            // 
            this.labelAllSumCart.AutoSize = true;
            this.labelAllSumCart.Location = new System.Drawing.Point(1016, 433);
            this.labelAllSumCart.Name = "labelAllSumCart";
            this.labelAllSumCart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelAllSumCart.Size = new System.Drawing.Size(59, 17);
            this.labelAllSumCart.TabIndex = 18;
            this.labelAllSumCart.Text = "All Sum:";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 553);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.tabControl1);
            this.Name = "main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.Load += new System.EventHandler(this.main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageEmployee.ResumeLayout(false);
            this.tabPageEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.tabPageSklad.ResumeLayout(false);
            this.tabPageSklad.PerformLayout();
            this.tabPageCash.ResumeLayout(false);
            this.tabPageCash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UDQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSklad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDQuantityDrugToCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEmployee;
        private System.Windows.Forms.TabPage tabPageSklad;
        private System.Windows.Forms.TabPage tabPageCash;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxPost;
        private System.Windows.Forms.TextBox textBoxSalary;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDrugName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewSklad;
        private System.Windows.Forms.NumericUpDown UDQuantity;
        private System.Windows.Forms.Button buttonDrugClear;
        private System.Windows.Forms.Button buttonDrugDelete;
        private System.Windows.Forms.Button buttonDrugChange;
        private System.Windows.Forms.Button buttonDrugAdd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox TextBoxRecipe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox TextBoxComposits;
        private System.Windows.Forms.Button buttonClearFormCart;
        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Label labelSumToCart;
        private System.Windows.Forms.NumericUpDown UDQuantityDrugToCart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBoxDrugNameToCart;
        private System.Windows.Forms.Label labelAllSumCart;
        private System.Windows.Forms.Button buttonBuyCart;
        private System.Windows.Forms.DataGridView dataGridViewCart;
    }
}