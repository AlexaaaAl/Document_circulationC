﻿
namespace Document_circulation
{
    partial class AddDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDocument));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.typeComboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.userComboBox2 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.IdlistBox = new System.Windows.Forms.ListBox();
            this.IdcomboBox = new System.Windows.Forms.ComboBox();
            this.DepcomboBox = new System.Windows.Forms.ComboBox();
            this.NameDeplistBox = new System.Windows.Forms.ListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IdDepComboBox = new System.Windows.Forms.ComboBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.document_circulation_pathDataSet = new Document_circulation.document_circulation_pathDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new Document_circulation.document_circulation_pathDataSetTableAdapters.usersTableAdapter();
            this.documentsTableAdapter = new Document_circulation.document_circulation_pathDataSetTableAdapters.documentsTableAdapter();
            this.document_circulation_pathDataSet1 = new Document_circulation.document_circulation_pathDataSet1();
            this.usersBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter1 = new Document_circulation.document_circulation_pathDataSet1TableAdapters.usersTableAdapter();
            this.documentsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.documentsTableAdapter1 = new Document_circulation.document_circulation_pathDataSet1TableAdapters.documentsTableAdapter();
            this.documentsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(392, 166);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(161, 18);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "(добавить срок исполнения)";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(176, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 29);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "-";
            // 
            // typeComboBox1
            // 
            this.typeComboBox1.DisplayMember = "status";
            this.typeComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeComboBox1.FormattingEnabled = true;
            this.typeComboBox1.Location = new System.Drawing.Point(174, 197);
            this.typeComboBox1.Name = "typeComboBox1";
            this.typeComboBox1.Size = new System.Drawing.Size(408, 29);
            this.typeComboBox1.TabIndex = 3;
            this.typeComboBox1.ValueMember = "status";
            this.typeComboBox1.SelectedIndexChanged += new System.EventHandler(this.typeComboBox1_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(14, 277);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(321, 256);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(629, 83);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(292, 112);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 21;
            this.listBox2.Location = new System.Drawing.Point(590, 375);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.Size = new System.Drawing.Size(337, 109);
            this.listBox2.TabIndex = 6;
            // 
            // userComboBox2
            // 
            this.userComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.userComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.userComboBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.userComboBox2.DisplayMember = "LAST_NAME";
            this.userComboBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userComboBox2.FormattingEnabled = true;
            this.userComboBox2.Location = new System.Drawing.Point(589, 260);
            this.userComboBox2.Name = "userComboBox2";
            this.userComboBox2.Size = new System.Drawing.Size(337, 29);
            this.userComboBox2.Sorted = true;
            this.userComboBox2.TabIndex = 9;
            this.userComboBox2.ValueMember = "LAST_NAME";
            this.userComboBox2.SelectedIndexChanged += new System.EventHandler(this.userComboBox2_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(589, 490);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 49);
            this.button4.TabIndex = 11;
            this.button4.Text = "Удалить получателя";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.OliveDrab;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button5.Location = new System.Drawing.Point(750, 544);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(177, 42);
            this.button5.TabIndex = 12;
            this.button5.Text = "Отправить";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Исходящий номер:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Срок исполнения";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(625, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Описание :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Тип документа";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(1, -68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 124);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker3.Location = new System.Drawing.Point(419, 58);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker3.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(11, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 21);
            this.label7.TabIndex = 35;
            this.label7.Text = "Входящий номер:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(388, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 21);
            this.label12.TabIndex = 44;
            this.label12.Text = "от:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(176, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(205, 29);
            this.textBox2.TabIndex = 34;
            this.textBox2.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(388, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 21);
            this.label9.TabIndex = 38;
            this.label9.Text = "от:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(419, 91);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker2.TabIndex = 39;
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(14, 277);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(267, 44);
            this.listBox3.TabIndex = 18;
            // 
            // IdlistBox
            // 
            this.IdlistBox.FormattingEnabled = true;
            this.IdlistBox.Location = new System.Drawing.Point(601, 376);
            this.IdlistBox.Name = "IdlistBox";
            this.IdlistBox.Size = new System.Drawing.Size(320, 108);
            this.IdlistBox.TabIndex = 19;
            // 
            // IdcomboBox
            // 
            this.IdcomboBox.FormattingEnabled = true;
            this.IdcomboBox.Location = new System.Drawing.Point(589, 262);
            this.IdcomboBox.Name = "IdcomboBox";
            this.IdcomboBox.Size = new System.Drawing.Size(337, 21);
            this.IdcomboBox.TabIndex = 20;
            // 
            // DepcomboBox
            // 
            this.DepcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DepcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DepcomboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DepcomboBox.FormattingEnabled = true;
            this.DepcomboBox.Location = new System.Drawing.Point(339, 260);
            this.DepcomboBox.Name = "DepcomboBox";
            this.DepcomboBox.Size = new System.Drawing.Size(243, 29);
            this.DepcomboBox.Sorted = true;
            this.DepcomboBox.TabIndex = 22;
            this.DepcomboBox.SelectedIndexChanged += new System.EventHandler(this.DepcomboBox_SelectedIndexChanged);
            // 
            // NameDeplistBox
            // 
            this.NameDeplistBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameDeplistBox.FormattingEnabled = true;
            this.NameDeplistBox.ItemHeight = 21;
            this.NameDeplistBox.Location = new System.Drawing.Point(345, 375);
            this.NameDeplistBox.Name = "NameDeplistBox";
            this.NameDeplistBox.Size = new System.Drawing.Size(237, 109);
            this.NameDeplistBox.TabIndex = 25;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(345, 490);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 48);
            this.button7.TabIndex = 26;
            this.button7.Text = "Удалить отдел";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(445, 490);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(137, 48);
            this.button8.TabIndex = 27;
            this.button8.Text = "Очистить поле (отдел)";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(750, 490);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(177, 48);
            this.button9.TabIndex = 28;
            this.button9.Text = "Очистить поле (получатели)";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(335, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 21);
            this.label5.TabIndex = 30;
            this.label5.Text = "Выбор отдела";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(585, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 21);
            this.label6.TabIndex = 31;
            this.label6.Text = "Выбор получателя";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // IdDepComboBox
            // 
            this.IdDepComboBox.FormattingEnabled = true;
            this.IdDepComboBox.Location = new System.Drawing.Point(339, 265);
            this.IdDepComboBox.Name = "IdDepComboBox";
            this.IdDepComboBox.Size = new System.Drawing.Size(195, 21);
            this.IdDepComboBox.TabIndex = 32;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(358, 389);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(126, 95);
            this.listBox4.TabIndex = 33;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox2.Location = new System.Drawing.Point(581, 555);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(164, 23);
            this.checkBox2.TabIndex = 36;
            this.checkBox2.Text = "от имени директора";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(176, 162);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(341, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(299, 21);
            this.label8.TabIndex = 40;
            this.label8.Text = "Отображение добавленных отделов";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(586, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(334, 21);
            this.label10.TabIndex = 41;
            this.label10.Text = "Отображение добавленных получателей";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(10, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 21);
            this.label11.TabIndex = 43;
            this.label11.Text = "За подписью от ";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DisplayMember = "status";
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(176, 128);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(406, 29);
            this.comboBox1.TabIndex = 42;
            this.comboBox1.ValueMember = "status";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(589, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(337, 30);
            this.button3.TabIndex = 21;
            this.button3.Text = "Добавить получателя";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(339, 295);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(243, 53);
            this.button6.TabIndex = 23;
            this.button6.Text = "Добавить отдел (для общей  рассылки)";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(174, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Удалить фаил";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(14, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Выбрать фаил";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // document_circulation_pathDataSet
            // 
            this.document_circulation_pathDataSet.DataSetName = "document_circulation_pathDataSet";
            this.document_circulation_pathDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            this.usersBindingSource.DataSource = this.document_circulation_pathDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // documentsTableAdapter
            // 
            this.documentsTableAdapter.ClearBeforeFill = true;
            // 
            // document_circulation_pathDataSet1
            // 
            this.document_circulation_pathDataSet1.DataSetName = "document_circulation_pathDataSet1";
            this.document_circulation_pathDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource4
            // 
            this.usersBindingSource4.DataMember = "users";
            this.usersBindingSource4.DataSource = this.document_circulation_pathDataSet1;
            this.usersBindingSource4.CurrentChanged += new System.EventHandler(this.usersBindingSource4_CurrentChanged);
            // 
            // usersTableAdapter1
            // 
            this.usersTableAdapter1.ClearBeforeFill = true;
            // 
            // documentsBindingSource1
            // 
            this.documentsBindingSource1.DataMember = "documents";
            this.documentsBindingSource1.DataSource = this.document_circulation_pathDataSet1;
            // 
            // documentsTableAdapter1
            // 
            this.documentsTableAdapter1.ClearBeforeFill = true;
            // 
            // documentsBindingSource2
            // 
            this.documentsBindingSource2.DataMember = "documents";
            this.documentsBindingSource2.DataSource = this.document_circulation_pathDataSet1;
            // 
            // AddDocument
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(938, 617);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.NameDeplistBox);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.DepcomboBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.userComboBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.typeComboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.IdlistBox);
            this.Controls.Add(this.IdcomboBox);
            this.Controls.Add(this.IdDepComboBox);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.label9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(693, 600);
            this.Name = "AddDocument";
            this.Text = "Создание нового письма";
            this.Load += new System.EventHandler(this.AddDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox typeComboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ComboBox userComboBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private document_circulation_pathDataSet document_circulation_pathDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private document_circulation_pathDataSetTableAdapters.usersTableAdapter usersTableAdapter;
        private document_circulation_pathDataSetTableAdapters.documentsTableAdapter documentsTableAdapter;
        private document_circulation_pathDataSet1 document_circulation_pathDataSet1;
        private System.Windows.Forms.BindingSource usersBindingSource4;
        private document_circulation_pathDataSet1TableAdapters.usersTableAdapter usersTableAdapter1;
        private System.Windows.Forms.BindingSource documentsBindingSource1;
        private document_circulation_pathDataSet1TableAdapters.documentsTableAdapter documentsTableAdapter1;
        private System.Windows.Forms.BindingSource documentsBindingSource2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox IdlistBox;
        private System.Windows.Forms.ComboBox IdcomboBox;
        private System.Windows.Forms.ComboBox DepcomboBox;
        private System.Windows.Forms.ListBox NameDeplistBox;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox IdDepComboBox;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}