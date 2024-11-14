using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Order
    {
        public int OrderId {  get; private set; }
        public List<Product> Products { get; private set; }
        
        public Order(int orderId, List<Product> products)
        {
            OrderId = orderId;
            Products = products;
        }
    }
}
