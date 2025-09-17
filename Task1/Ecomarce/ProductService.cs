using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal class ProductService
    {
        private  List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
        }

      
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Invalid Product.");
                return;
            }

            _products.Add(product);
            Console.WriteLine($" Product {product.Name} added successfully.");
        }

       
        public void UpdateProduct(int id, string name, string description, decimal price)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            product.Name = name;
            product.Description = description;
            product.Price = price;

            Console.WriteLine($"Product {id} updated");
        }

       
        public void DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            _products.Remove(product);
            Console.WriteLine($"Product {id} deleted.");
        }

       
        public void ShowProducts()
        {
            if (!_products.Any())
            {
                Console.WriteLine("No products !!!");
                return;
            }

            Console.WriteLine("\nProduct List:");
            foreach (var p in _products)
            {
                Console.WriteLine(p.ToString());
            }
        }

       
        public List<Product> GetProducts()
        {
            return _products.ToList();
        }
    }
}
