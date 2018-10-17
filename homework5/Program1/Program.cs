using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    


    class Program1
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            //初始化客户
            Custom custom1 = new Custom(1, "mayun");
            Custom custom2 = new Custom(2, "mahuateng");
            Custom custom3 = new Custom(3, "wangjianlin");

            //初始化订单订单
            OrderService.addOrder(orders, new Order(1,custom1));
            OrderService.addOrder(orders, new Order(2,custom2));
            OrderService.addOrder(orders, new Order(3, custom3));
            orders[0].addOrderDetails(new OrderDetails("001", "Taobao", 7000));
            orders[0].addOrderDetails(new OrderDetails("002", "Alipay", 3001));
            orders[1].addOrderDetails(new OrderDetails("007", "Tecent", 5000));
            orders[1].addOrderDetails(new OrderDetails("003", "WeChat", 4999));
            orders[2].addOrderDetails(new OrderDetails("004", "Wanda", 10001));
            //删除第二个订单
            //OrderService.removeOrder(orders, orders[1]);
            //查找订单
            //int i = OrderService.findOrderByString(orders, "Taobao");
            //int x = orders[i].findOrderDetailsByString("Taobao");
            //修改订单
            //OrderService.changeOrder(orders, i, x, 1, "huichuangali");
            //展示订单
            foreach (Order order in orders)
            {
                Console.WriteLine("订单" + order.id);
                Console.WriteLine(order);
            }
            OrderService.showOrderByCustom(orders, "mayun");
            OrderService.showOrderByGoodsName(orders, "Alipay");
            OrderService.showOrderByGoodsId(orders, "004");
            OrderService.showOrderMoreThanNum(orders, 10000);
            Console.ReadKey();
        }
    }

}
