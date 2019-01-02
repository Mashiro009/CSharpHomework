using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
                Convert.ToString(order.Details.Count + 1), goods, uint.Parse(textBox3.Text));
            order.AddDetails(orderDetail);
            detailsBindingSource.DataSource = null;
            detailsBindingSource.DataSource = order.Details;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //order.Id = textBox1.Text;
            if (!checkPhoneNumber(textBox1.Text))
                throw new Exception("电话格式不正确，应为11位");

            order.Customer = new ordertest.Customer(textBox1.Text,textBox2.Text);
            order.NewId();
            Form1.os.AddOrder(order);
            Form1.orderBindingSource.DataSource = Form1.os.Dict.Values.ToList();
            this.Close();
        }

        private bool checkPhoneNumber(string number)
        {
            Regex regex = new Regex("[0-9]{11}");
            bool ok = regex.IsMatch(number);
            return ok;
        }
    }
}
