using ExercicioComposicao.Entities.Enums;
using ExercicioComposicao.Entities;
using System.Globalization;

namespace ExercicioComposicao
{
    class Program
    {
        static void Main(String[] args)
        {
            DateTime momento = DateTime.Now;
            Console.WriteLine("Enter Cliente Data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Brith date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Order status:");
            Console.Write("Status  (PendingPayment/Processing/Shipped/Delivered): ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());   

            Client client = new Client(name, email, date);
            Order order = new Order(momento, status, client);

            Console.Write("How Many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter ##{i} item data:");
                Console.Write("Product Name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(nameProduct, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }
            Console.WriteLine(order);
        }
    }
}
