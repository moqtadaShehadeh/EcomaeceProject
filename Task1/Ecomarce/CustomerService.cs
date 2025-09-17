using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal class CustomerService
    {
        private readonly List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();
        }

      
        public Customer Register(string name, string email, string password, CustomerType type = CustomerType.Normal)
        {
         
            if (_customers.Any(c => c.Email == email))
            {
                Console.WriteLine("Email already exists.");
                return null;
            }

            var customer = new Customer(name, email, password, type);
            _customers.Add(customer);

            Console.WriteLine($"Customer {customer.Name} registered successfully with Id {customer.Id}.");
            return customer;
        }

       
        public Customer Login(string email, string password)
        {
            var customer = _customers.FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer == null)
            {
                Console.WriteLine("Invalid email or password.");
                return null;
            }

            Console.WriteLine($"Welcome back, {customer.Name}!");
            return customer;
        }

     
        public void ShowCustomers()
        {
            if (!_customers.Any())
            {
                Console.WriteLine(" No customers .");
                return;
            }

            Console.WriteLine("\nCustomers :");
            foreach (var c in _customers)
            {
                Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Email: {c.Email}, Type: {c.Type}");
            }
        }

      
        public List<Customer> GetCustomers()
        {
            return _customers.ToList();
        }
    }
}
