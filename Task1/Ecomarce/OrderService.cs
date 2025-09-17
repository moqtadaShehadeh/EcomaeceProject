using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal class OrderService
    {
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        
        public Order CreateOrder(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Invalid Customer.");
                return null;
            }

            var order = new Order(customer);
            _orders.Add(order);
            customer.Orders.Add(order);

            Console.WriteLine($"Order {order.Id} created for {customer.Name}.");
            return order;
        }

       
        public void AddProductToOrder(int orderId, Product product)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            order.AddProduct(product);
            Console.WriteLine($"Product {product.Name} added to Order {order.Id}.");
        }

       
        public void ShowOrders()
        {
            if (!_orders.Any())
            {
                Console.WriteLine("No orders available.");
                return;
            }

            Console.WriteLine("\n Orders :");
            foreach (var o in _orders)
            {
                Console.WriteLine($"Order {o.Id} | Customer: {o.Customer.Name} | Products: {o.Products.Count} | Total: {o.GetTotal()}");
            }
        }

       
        public void PrintOrderBill(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            order.PrintBill();
        }

        
        public List<Order> GetOrders()
        {
            return _orders.ToList();
        }
    }
}
