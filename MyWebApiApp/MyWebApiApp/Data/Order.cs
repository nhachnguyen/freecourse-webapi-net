using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Data
{
    public enum OrderStatus
    {
        New = 0, Payment = 1, Completed = 2, Canceled = -1
    }
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string DeliveryName { get; set; }

        public string DeliveryAddress { get; set; }

        public string Phone { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
