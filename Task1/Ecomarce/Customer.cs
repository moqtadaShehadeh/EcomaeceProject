using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce

{
    public enum CustomerType
    {
        Normal,
        VIP
    }
    internal class Customer : User
    {
        private static int _idCounter = 1000;

        public CustomerType Type { get; private set; }
        public List<Order> Orders { get; private set; }

        public Customer(string name, string email, string password, CustomerType type = CustomerType.Normal)
        {
            Id = _idCounter++;
            Name = name;
            Email = email;
            Password = password;
            Type = type;
            Orders = new List<Order>();
        }

        public override Role Access()
        {
            return Role.Customer;
        }
    }
    }
