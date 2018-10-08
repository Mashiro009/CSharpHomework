using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        public int id { get; set; }
        public List<OrderDetails> orderList = new List<OrderDetails>();
        public Order(int id)
        {
            this.id = id;
        }
        public void addOrderDetails(OrderDetails orderDetails)
        {
            orderList.Add(orderDetails);
        }
        public void removeOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                orderList.Remove(orderDetails);
            }
            catch(Exception e)
            {
                Console.WriteLine("订单内容为空，无法删除");
            }

        }
        public int findOrderDetailsByString(string str)
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].pairs.ContainsValue(str))
                    return i;
            }
            return -1;
        }
        public void showOrderDetails()
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                Console.WriteLine("订单号：" + orderList[i].pairs[0]
                    + " 客人：" + orderList[i].pairs[1] + " 商品：" + orderList[i].pairs[2]);
            }
        }
    }

    class OrderService
    {
        public static void addOrder(List<Order> list,Order order)
        {
            list.Add(order);
        }

        public static void removeOrder(List<Order> list, Order order)
        {
            try
            {
                list.Remove(order);
            }
            catch(Exception e)
            {
                Console.WriteLine("订单为空无法删除");
            }
        }
        public static int findOrderByString(List<Order> list, string str)
        {
            for (int i = 0; i < list.Count; i++) 
            {
                foreach(OrderDetails orderDetails in list[i].orderList)
                {
                    if(orderDetails.pairs.ContainsValue(str))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static void changeOrder(List<Order> list,
            int i, int x, int y, string str)//修改i个订单第x行第y个属性
        {
            try
            {
                list[i].orderList[x].pairs[y] = str;
            }
            catch (Exception e)
            {
                Console.WriteLine("出现错误无法修改");
            }
        }
    }

    class OrderDetails
    {
        public Dictionary<int,string> pairs = new Dictionary<int, string>();
        public OrderDetails(string id,string custom,string goods)
        {
            pairs[0] = id;
            pairs[1] = custom;
            pairs[2] = goods;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            //初始化订单订单
            OrderService.addOrder(orders, new Order(1));
            OrderService.addOrder(orders, new Order(2));
            orders[0].addOrderDetails(new OrderDetails("001", "mayun", "Taobao"));
            orders[0].addOrderDetails(new OrderDetails("002", "mahuateng", "Tecent"));
            orders[1].addOrderDetails(new OrderDetails("007","wangjianlin","Wanda"));
            //删除第二个订单
            OrderService.removeOrder(orders, orders[1]);
            //查找订单
            int i = OrderService.findOrderByString(orders, "mayun");
            int x = orders[i].findOrderDetailsByString("mayun");
            //修改订单
            OrderService.changeOrder(orders, i, x, 2, "huichuangali");
            //展示订单
            foreach(Order order in orders)
            {
                Console.WriteLine("订单" + order.id);
                order.showOrderDetails();
            }
            Console.ReadKey();
        }
    }
}
