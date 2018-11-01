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
    public partial class Form3 : Form
    {
        private static Dictionary<string, double> priceList
            = new Dictionary<string, double>();
        private ordertest.Order order;
        public Form3()
        {
            InitializeComponent();
            priceList["Milk"] = 69.9;
            priceList["eggs"] = 4.99;
            priceList["apple"] = 5.99;
            priceList["banana"] = 10;
            priceList["orange"] = 12;
            priceList["cookie"] = 15;
            order = new ordertest.Order();
            detailsBindingSource.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string goodName = listBox1.SelectedItem.ToString();
            ordertest.Goods goods = new ordertest.Goods(
                Convert.ToUInt32(listBox1.SelectedIndex), goodName, priceList[goodName]);
            ordertest.OrderDetail orderDetail = new ordertest.OrderDetail(
                Convert.ToUInt32(order.Details.Count + 1), goods, uint.Parse(textBox3.Text));
            order.AddDetails(orderDetail);
            detailsBindingSource.DataSource = null;
            detailsBindingSource.DataSource = order.Details;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            order.Id = uint.Parse(textBox1.Text);
            order.Customer = new ordertest.Customer(textBox2.Text);
            Form1.os.AddOrder(order);
            Form1.orderBindingSource.DataSource = Form1.os.Dict.Values.ToList();
            this.Close();
        }
    }
}
