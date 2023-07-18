namespace ECommerce1.Models
{
    public class Order : BaseEntity
    {
        public int OrderID { get; set; }
        public Guid UserID { get; set; } // Foreign Key
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        // Navigation Properties
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
