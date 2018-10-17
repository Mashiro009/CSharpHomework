using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class OrderDetails
    {
        public Dictionary<int, string> pairs = new Dictionary<int, string>();
        public int money { set; get; }
        public OrderDetails(string id, string goods,int money)
        {
            pairs[0] = id;
            pairs[1] = goods;
            this.money = money;
        }
    }

}
