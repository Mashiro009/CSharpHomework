using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    /// <summary>
    /// Order class : all orderDetails
    /// to record each goods and its quantity in this ordering
    /// </summary>
    public class Order {
        
        public List<OrderDetail> Details
        {
            get => this.details;
            set { }
        }
        /// <summary>
        /// order id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// the man who orders goods
        /// </summary>
        public Customer Customer { get; set; }


        public double Amount
        {
            get
            {
                return details.Sum(d => d.Goods.Price * d.Quantity);
            }
            set { }

        }



        private List<OrderDetail> details = new List<OrderDetail>();
        private static uint i = 0;

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order(Customer customer) {
            string str = string.Format("{0:yyyyMMdd}", DateTime.Now);
            Id = str + i.ToString("000");
            Customer = customer;
            i = (i + 1) % 1000;
        }

        public Order() { }

            
        public void NewId()
        {
            string str = string.Format("{0:yyyyMMdd}", DateTime.Now);
            Id = str + i.ToString("000");
            i = (i + 1) % 1000;
        }


        /// <summary>
        /// add new orderDetail to order
        /// </summary>
        /// <param name="orderDetail">the new orderDetail which will be added</param>
        public void AddDetails(OrderDetail orderDetail) {
            if (this.Details.Contains(orderDetail))  {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }

        /// <summary>
        /// remove orderDetail by orderDetailId from order
        /// </summary>
        /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
        public void RemoveDetails(string orderDetailId) {
            details.RemoveAll(d =>d.Id==orderDetailId);
        }


        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Order object</returns>
        public override string ToString() {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer.Name}),Amount:{Amount}";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
