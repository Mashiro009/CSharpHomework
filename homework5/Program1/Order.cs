using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Order
    {
        public int id { get; set; }
        public Custom custom { get; set; }
        public List<OrderDetails> orderList = new List<OrderDetails>();
        public Order(int id,Custom custom)
        {
            this.id = id;
            this.custom = custom;
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
            catch (Exception e)
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
        public int orderMoneySum()
        {
            int orderMoney = 0;
            foreach(OrderDetails orderDetails in orderList)
            {
                orderMoney += orderDetails.money;
            }
            return orderMoney;
        }
        public override string ToString()
        {
            string str = null;
            str += $"{custom}\n";
            for (int i = 0; i < orderList.Count; i++)
            {
                str += 
                    $"订单号：{orderList[i].pairs[0]} " +
                    $"商品：{orderList[i].pairs[1]} 价格:{orderList[i].money}\n";
            }
            return str;
        }
    }

}
