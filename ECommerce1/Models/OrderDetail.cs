namespace ECommerce1.Models
{
    public class OrderDetail : BaseEntity
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; } // Foreign Key
        public int ProductID { get; set; } // Foreign Key
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // Navigation Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
