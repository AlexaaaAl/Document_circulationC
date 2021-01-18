
namespace Document_circulation
{
    partial class MenuController
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.orders = new System.Windows.Forms.RadioButton();
            this.incomingMailMoscow = new System.Windows.Forms.RadioButton();
            this.incomingMail = new System.Windows.Forms.RadioButton();
            this.internalDocuments = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьНовыйДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.document_circulation_pathDataSet = new Document_circulation.document_circulation_pathDataSet();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Document_circulation.DataSet1();
            this.usersTableAdapter = new Document_circulation.document_circulation_pathDataSetTableAdapters.usersTableAdapter();
            this.documentsTableAdapter = new Document_circulation.document_circulation_pathDataSetTableAdapters.documentsTableAdapter();
            this.documentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.documentsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.document_circulation_pathDataSet1 = new Document_circulation.document_circulation_pathDataSet1();
            this.v1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v1TableAdapter = new Document_circulation.document_circulation_pathDataSet1TableAdapters.v1TableAdapter();
            this.выходToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.окноАвторизацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьПрограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.orders);
            this.panel1.Controls.Add(this.incomingMailMoscow);
            this.panel1.Controls.Add(this.incomingMail);
            this.panel1.Controls.Add(this.internalDocuments);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 113);
            this.panel1.TabIndex = 0;
            // 
            // orders
            // 
            this.orders.AutoSize = true;
            this.orders.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orders.Location = new System.Drawing.Point(781, 82);
            this.orders.Name = "orders";
            this.orders.Size = new System.Drawing.Size(99, 25);
            this.orders.TabIndex = 6;
            this.orders.Text = "Приказы";
            this.orders.UseVisualStyleBackColor = true;
            // 
            // incomingMailMoscow
            // 
            this.incomingMailMoscow.AutoSize = true;
            this.incomingMailMoscow.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incomingMailMoscow.Location = new System.Drawing.Point(781, 59);
            this.incomingMailMoscow.Name = "incomingMailMoscow";
            this.incomingMailMoscow.Size = new System.Drawing.Size(446, 25);
            this.incomingMailMoscow.TabIndex = 5;
            this.incomingMailMoscow.Text = "Регистрация входящей корреспонденции г. Москвы";
            this.incomingMailMoscow.UseVisualStyleBackColor = true;
            // 
            // incomingMail
            // 
            this.incomingMail.AutoSize = true;
            this.incomingMail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incomingMail.Location = new System.Drawing.Point(781, 36);
            this.incomingMail.Name = "incomingMail";
            this.incomingMail.Size = new System.Drawing.Size(364, 25);
            this.incomingMail.TabIndex = 4;
            this.incomingMail.Text = "Регистрация входящей корреспонденции ";
            this.incomingMail.UseVisualStyleBackColor = true;
            this.incomingMail.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // internalDocuments
            // 
            this.internalDocuments.AutoSize = true;
            this.internalDocuments.Checked = true;
            this.internalDocuments.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.internalDocuments.Location = new System.Drawing.Point(781, 13);
            this.internalDocuments.Name = "internalDocuments";
            this.internalDocuments.Size = new System.Drawing.Size(327, 25);
            this.internalDocuments.TabIndex = 3;
            this.internalDocuments.TabStop = true;
            this.internalDocuments.Text = "Регистрация внутренних документов";
            this.internalDocuments.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(320, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(341, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Создать новый документ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поиск";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.menuStrip2);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1441, 32);
            this.panel2.TabIndex = 1;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.действияToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.выходToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1441, 29);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьНовыйДокументToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 25);
            this.toolStripMenuItem1.Text = "Фаил";
            // 
            // создатьНовыйДокументToolStripMenuItem
            // 
            this.создатьНовыйДокументToolStripMenuItem.Name = "создатьНовыйДокументToolStripMenuItem";
            this.создатьНовыйДокументToolStripMenuItem.Size = new System.Drawing.Size(300, 30);
            this.создатьНовыйДокументToolStripMenuItem.Text = "Создать новый документ";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПользователяToolStripMenuItem});
            this.действияToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(98, 25);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // добавитьПользователяToolStripMenuItem
            // 
            this.добавитьПользователяToolStripMenuItem.Name = "добавитьПользователяToolStripMenuItem";
            this.добавитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(292, 30);
            this.добавитьПользователяToolStripMenuItem.Text = "Добавить пользователя";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(90, 25);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(202, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.Location = new System.Drawing.Point(111, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1326, 537);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(0, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 537);
            this.panel3.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(16, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 72);
            this.button2.TabIndex = 0;
            this.button2.Text = "Открыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "documents";
            this.bindingSource1.DataSource = this.document_circulation_pathDataSet;
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // document_circulation_pathDataSet
            // 
            this.document_circulation_pathDataSet.DataSetName = "document_circulation_pathDataSet";
            this.document_circulation_pathDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // documentsTableAdapter
            // 
            this.documentsTableAdapter.ClearBeforeFill = true;
            // 
            // documentsBindingSource
            // 
            this.documentsBindingSource.DataMember = "documents";
            this.documentsBindingSource.DataSource = this.document_circulation_pathDataSet;
            // 
            // documentsBindingSource1
            // 
            this.documentsBindingSource1.DataMember = "documents";
            this.documentsBindingSource1.DataSource = this.document_circulation_pathDataSet;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // document_circulation_pathDataSet1
            // 
            this.document_circulation_pathDataSet1.DataSetName = "document_circulation_pathDataSet1";
            this.document_circulation_pathDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v1BindingSource
            // 
            this.v1BindingSource.DataMember = "v1";
            this.v1BindingSource.DataSource = this.document_circulation_pathDataSet1;
            // 
            // v1TableAdapter
            // 
            this.v1TableAdapter.ClearBeforeFill = true;
            // 
            // выходToolStripMenuItem1
            // 
            this.выходToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.окноАвторизацииToolStripMenuItem,
            this.закрытьПрограммуToolStripMenuItem});
            this.выходToolStripMenuItem1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
            this.выходToolStripMenuItem1.Size = new System.Drawing.Size(74, 25);
            this.выходToolStripMenuItem1.Text = "Выход";
            // 
            // окноАвторизацииToolStripMenuItem
            // 
            this.окноАвторизацииToolStripMenuItem.Name = "окноАвторизацииToolStripMenuItem";
            this.окноАвторизацииToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.окноАвторизацииToolStripMenuItem.Text = "Окно авторизации";
            this.окноАвторизацииToolStripMenuItem.Click += new System.EventHandler(this.окноАвторизацииToolStripMenuItem_Click);
            // 
            // закрытьПрограммуToolStripMenuItem
            // 
            this.закрытьПрограммуToolStripMenuItem.Name = "закрытьПрограммуToolStripMenuItem";
            this.закрытьПрограммуToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.закрытьПрограммуToolStripMenuItem.Text = "Закрыть программу";
            this.закрытьПрограммуToolStripMenuItem.Click += new System.EventHandler(this.закрытьПрограммуToolStripMenuItem_Click);
            // 
            // MenuController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 680);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "MenuController";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MenuController_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document_circulation_pathDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton orders;
        private System.Windows.Forms.RadioButton incomingMailMoscow;
        private System.Windows.Forms.RadioButton incomingMail;
        private System.Windows.Forms.RadioButton internalDocuments;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem создатьНовыйДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private document_circulation_pathDataSet document_circulation_pathDataSet;
        private document_circulation_pathDataSetTableAdapters.usersTableAdapter usersTableAdapter;
        private document_circulation_pathDataSetTableAdapters.documentsTableAdapter documentsTableAdapter;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource documentsBindingSource1;
        private System.Windows.Forms.BindingSource documentsBindingSource;
        private System.Windows.Forms.Timer timer1;
        private document_circulation_pathDataSet1 document_circulation_pathDataSet1;
        private System.Windows.Forms.BindingSource v1BindingSource;
        private document_circulation_pathDataSet1TableAdapters.v1TableAdapter v1TableAdapter;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem окноАвторизацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьПрограммуToolStripMenuItem;
    }
}