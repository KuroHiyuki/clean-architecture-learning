using TechStore.Domain.Enums;

namespace TechStore.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public virtual User? User { get; set; }
        public virtual List<Product>? Products { get; set; }
        public virtual Payment? Payment { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
