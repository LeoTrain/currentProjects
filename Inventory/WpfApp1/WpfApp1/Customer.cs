using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        private string _passwordHash;

        public string PasswordHash
        {
            get { return _passwordHash; }
            set
            {
                if (_passwordHash == "")
                    throw new ArgumentException("Password cannot be empty.");
                _passwordHash = value;
            }
        }

        public Customer() { }

        public Customer(int customerID,  string name, string email, string passwordHash)
        {
            CustomerID = customerID;
            Name = name;
            Email = email;
            _passwordHash = passwordHash;
        }
    }
}
