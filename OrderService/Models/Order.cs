
using ProductSerivceReal.Models;

namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Products { get; set; }
    }
}
