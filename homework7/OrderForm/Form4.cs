using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{

    public partial class Form4 : Form
    {
        //public uint Id { set; get; }
        public Form4()
        {
            InitializeComponent();
        }

        public Form4(string id, string customerName)
        {
            InitializeComponent();
            label2.Text = id;
            textBox1.Text = customerName;
            detailsBindingSource.DataSource = Form1.os.Dict[uint.Parse(id)].Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.os.UpdateCustomer(uint.Parse(label2.Text), new ordertest.Customer(textBox1.Text));
            Form1.orderBindingSource.DataSource = Form1.os.Dict.Values.ToList();
            this.Close();
        }
    }
}
