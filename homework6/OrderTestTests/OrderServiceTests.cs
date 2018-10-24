using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using ordertest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ordertest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        //[TestMethod()]
        //public void AddOrderTest()
        //{
        //    Assert.Fail();
        //}
        //正确添加订单
        [TestMethod()]
        public void AddOrderTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);

            Dictionary<uint, Order> ans = new Dictionary<uint, Order>();
            ans[order1.Id] = order1;
            CollectionAssert.AreEqual(ans, os.Dict);
            Assert.AreEqual(os.Dict[order1.Id], order1);

        }

        //错误重复添加订单
        [TestMethod()]
        public void AddOrderTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order1);

        }

        //正确删除订单
        [TestMethod()]
        public void RemoveOrderTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 800);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.RemoveOrder(2);

            Dictionary<uint, Order> ans = new Dictionary<uint, Order>();
            ans[order1.Id] = order1;
            CollectionAssert.AreEqual(os.Dict, ans);
        }

        //重复删除订单
        [TestMethod()]
        public void RemoveOrderTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 800);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            //os.AddOrder(order1);
            //os.AddOrder(order2);
            os.RemoveOrder(order2.Id);
            os.RemoveOrder(order2.Id);

        }

        //正确测试
        [TestMethod()]
        public void GetByIdTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);

            Order order = os.GetById(order1.Id);
            Assert.AreEqual(order1, order);

        }


        //错误测试
        [TestMethod()]
        public void GetByIdTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);

            Order order = os.GetById(2);
            Assert.AreEqual(order1, order);

        }

        //正确测试
        [TestMethod()]
        public void QueryByGoodsNameTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);

            List<Order> order = os.QueryByGoodsName("Milk");

            Assert.AreEqual(order1, order[0]);
        }



        //错误测试
        [TestMethod()]
        public void QueryByGoodsNameTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);

            List<Order> order = os.QueryByGoodsName("Milk1");

            Assert.AreEqual(order1, order[0]);
        }


        [TestMethod()]
        public void XmlSerializeImportTest1()
        {
            Assert.Fail();
        }
    }
}