using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ordertest;

namespace OrderForm
{
    public partial class Form1 : Form
    {
        public static OrderService os;
        public Form1()
        {

            InitializeComponent();

            //
            //Customer customer1 = new Customer("13288654452", "Customer1");
            //Customer customer2 = new Customer("15644832267", "Customer2");

            //Goods milk = new Goods(1, "Milk", 69.9);
            //Goods eggs = new Goods(2, "eggs", 4.99);
            //Goods apple = new Goods(3, "apple", 5.59);

            //OrderDetail orderDetails1 = new OrderDetail(1, apple, 800);
            //OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            //OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            //Order order1 = new Order(customer1);
            //Order order2 = new Order(customer2);
            //Order order3 = new Order(customer2);
            //order1.AddDetails(orderDetails1);
            //order1.AddDetails(orderDetails2);
            //order1.AddDetails(orderDetails3);
            ////order1.AddOrderDetails(orderDetails3);
            //order2.AddDetails(orderDetails2);
            //order2.AddDetails(orderDetails3);
            //order3.AddDetails(orderDetails3);

            os = new OrderService();
            //os.AddOrder(order1);
            //os.AddOrder(order2);
            //os.AddOrder(order3);

            //
            orderBindingSource.DataSource = os.Dict.Values.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //orderBindingSource.DataSource = os.Dict.Values.Where(
            //    od => od.Id == Int32.Parse(textBox1.Text)).ToList();
            orderBindingSource.DataSource = os.GetById(textBox1.Text);
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = os.QueryByCustomerName(textBox2.Text);
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = os.QueryByGoodsName(textBox3.Text);
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string i = str;
            new Form2(i).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            new Form4(id, name).ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            os.RemoveOrder(s);
            orderBindingSource.DataSource = os.Dict.Values.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = @"..\..\s.xml";
            os.XmlSerializeExport(xmlser, xmlFileName);
            os.xsltToHtml();
        }
    }
}
