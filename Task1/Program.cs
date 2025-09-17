using Task1.Ecomarce;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();
            var customerService = new CustomerService();
            var orderService = new OrderService();

            Customer currentCustomer = null;

            while (true)
            {
              
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Add Product");
                Console.WriteLine("4. Show Products");
                Console.WriteLine("5. Create Order");
                Console.WriteLine("6. Show Orders");
                Console.WriteLine("7. Print Bill");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        Console.Write("Enter Name: ");
                        var name = Console.ReadLine();

                        Console.Write("Enter Email: ");
                        var email = Console.ReadLine();

                        Console.Write("Enter Password: ");
                        var password = Console.ReadLine();

                        Console.Write("Customer Type 0 = Normal && 1 = VIP : ");
                        var typeInput = Console.ReadLine();
                        var type = typeInput == "1" ? CustomerType.VIP : CustomerType.Normal;

                        currentCustomer = customerService.Register(name, email, password, type);
                        break;

                    case "2": 
                        Console.Write("Enter Email: ");
                        var loginEmail = Console.ReadLine();

                        Console.Write("Enter Password: ");
                        var loginPassword = Console.ReadLine();

                        currentCustomer = customerService.Login(loginEmail, loginPassword);
                        break;

                    case "3": 
                        Console.Write("Product Id: ");
                        var pid = int.Parse(Console.ReadLine());

                        Console.Write("Product Name: ");
                        var pname = Console.ReadLine();

                        Console.Write("Description: ");
                        var pdesc = Console.ReadLine();

                        Console.Write("Price: ");
                        var pprice = decimal.Parse(Console.ReadLine());

                        productService.AddProduct(new Product
                        {
                            Id = pid,
                            Name = pname,
                            Description = pdesc,
                            Price = pprice
                        });
                        break;

                    case "4": 
                        productService.ShowProducts();
                        break;

                    case "5": 
                        if (currentCustomer == null)
                        {
                            Console.WriteLine("You must login first");
                            break;
                        }

                        var order = orderService.CreateOrder(currentCustomer);

                        Console.Write("How many products to add");
                        var count = int.Parse(Console.ReadLine());

                        for (int i = 0; i < count; i++)
                        {
                            Console.Write("Enter Product Id: ");
                            var prodId = int.Parse(Console.ReadLine());

                            var product = productService.GetProducts().FirstOrDefault(p => p.Id == prodId);
                            if (product != null)
                            {
                                orderService.AddProductToOrder(order.Id, product);
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        break;

                    case "6": 
                        orderService.ShowOrders();
                        break;

                    case "7": 
                        Console.Write("Enter Order Id: ");
                        var oid = int.Parse(Console.ReadLine());
                        orderService.PrintOrderBill(oid);
                        break;

                    case "0":
                        Console.WriteLine("Ended program");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!!!");
                        break;
                }
            }
        }
    }
}
