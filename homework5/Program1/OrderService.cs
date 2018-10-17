using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class OrderService
    {
        public static void addOrder(List<Order> list, Order order)
        {
            list.Add(order);
        }

        public static void removeOrder(List<Order> list, Order order)
        {
            try
            {
                list.Remove(order);
            }
            catch (Exception e)
            {
                Console.WriteLine("订单为空无法删除");
            }
        }
        public static int findOrderByString(List<Order> list, string str)
        {
            for (int i = 0; i < list.Count; i++)
            {
                foreach (OrderDetails orderDetails in list[i].orderList)
                {
                    if (orderDetails.pairs.ContainsValue(str))
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

        public static void showOrderByCustom(List<Order> list, string str)
        {
            var query = from order in list
                        where order.custom.Name == str
                        select order;

            foreach (Order order in query)
            {
                int flag = 0;
                if(flag!= order.id)
                {
                    flag = order.id;
                    Console.WriteLine("订单" + order.id);
                }

                Console.WriteLine(order);
            }
        }
        public static void showOrderByGoodsName(List<Order> list, string str)
        {
            var query = from order in list
                        from orderDetails in order.orderList
                        where orderDetails.pairs[1] == str
                        select order;
            foreach (Order order in query)
            {
                int flag = 0;
                if (flag != order.id)
                {
                    flag = order.id;
                    Console.WriteLine("订单" + order.id);
                }
                Console.WriteLine(order);
            }
        }
        public static void showOrderByGoodsId(List<Order> list, string str)
        {
            var query = from order in list
                        from orderDetails in order.orderList
                        where orderDetails.pairs[0] == str
                        select order;

            foreach (Order order in query)
            {
                int flag = 0;
                if (flag != order.id)
                {
                    flag = order.id;
                    Console.WriteLine("订单" + order.id);
                }
                Console.WriteLine(order);
            }
        }
        public static void showOrderMoreThanNum(List<Order> list, int num)
        {
            var query = from order in list
                        where order.orderMoneySum() > 10000
                        select order;

            foreach (Order order in query)
            {
                int flag = 0;
                if (flag != order.id)
                {
                    flag = order.id;
                    Console.WriteLine("订单" + order.id);
                }
                Console.WriteLine(order);
            }
        }
    }

}
