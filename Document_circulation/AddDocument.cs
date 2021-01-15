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
    public partial class AddDocument : Form
    {
        public AddDocument()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddDocument_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.documents". При необходимости она может быть перемещена или удалена.
            this.documentsTableAdapter1.Fill(this.document_circulation_pathDataSet1.documents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "document_circulation_pathDataSet1.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter1.Fill(this.document_circulation_pathDataSet1.users);


        }

        private void usersBindingSource4_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
