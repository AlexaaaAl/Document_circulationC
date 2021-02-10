using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_circulation
{
    public partial class Form2 : Form
    {
        public TextBox TextBox1=new TextBox();
        public Form2()
        {
            InitializeComponent();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.TextBox1.AcceptsReturn = true;
            this.TextBox1.AcceptsTab = true;
            this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox1.Multiline = true;
            this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            
            // 
            // Form1
            // 
            this.Controls.Add(this.TextBox1);
            this.AcceptButton=ok;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //l
        }

        private void ok_Click(object sender, EventArgs e)
        {          
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
