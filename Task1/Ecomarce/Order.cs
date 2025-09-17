using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal class Order
    {
        private static int _idCounter = 2000;

        public int Id { get; private set; }
        public Customer Customer { get; private set; }
        public List<Product> Products { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Order(Customer customer)
        {
            Id = _idCounter++;
            Customer = customer;
            Products = new List<Product>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                return;
            Products.Add(product);
            UpdatedAt = DateTime.Now;
        }

        public decimal GetTotal()
        {
            return Products.Sum(p => p.Price);
        }

        public void PrintBill()
        {
            Console.WriteLine($"\n Bill for Customer: {Customer.Name}");
            foreach (var p in Products)
            {
                Console.WriteLine($"{p.Name} ===== (${p.Price})");
            }

            var discount = Discount.GetDiscount(Customer.Type);
            var total = GetTotal();
            var finalPrice = total - (total * (decimal)discount);

            Console.WriteLine($"Subtotal: {total}");
            Console.WriteLine($"Discount: {discount * 100}%");
            Console.WriteLine($"Total After Discount: {finalPrice}\n");
        }
    }
}
