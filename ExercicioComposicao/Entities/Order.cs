using ExercicioComposicao.Entities.Enums;
using ExercicioComposicao.Entities;
using System.Text;
using System.Globalization;

namespace ExercicioComposicao.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> ListOrder { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            ListOrder.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            ListOrder.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in ListOrder)
            {
                sum = sum + item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order Items:");
            foreach (OrderItem orderItem in ListOrder)
            {
                sb.Append(orderItem.Product.Name);
                sb.Append(", $");
                sb.Append(orderItem.Product.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(orderItem.Quantity);
                sb.Append(", Subtotal: $");
                sb.AppendLine(orderItem.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.Append("Total Price: $");
            sb.Append(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
