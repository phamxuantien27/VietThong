using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiamSat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetStudent_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            string ID = txtGROUP_NAME.Text;
            DataTable student = client.Camera(ID);
       
            dataGridView1.DataSource = student;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.WebService2SoapClient client = new ServiceReference2.WebService2SoapClient();
            string ID = textBox1.Text;
            DataTable student = client.ViTri(ID);

            dataGridView2.DataSource = student;
        }
    }
}
