using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public double Price {  get; set; }
        public int Amount { get; set; }

        public Product() { }
        public Product(int id, string name, string definition, double price, int amount)
        {
            ProductID = id;
            Name = name;
            Definition = definition;
            Price = price;
            Amount = amount;
        }

        public void ChangeAmount(int newAmount)
        {
            if (newAmount >= 0)
                Amount = newAmount;
        }
    }
}
