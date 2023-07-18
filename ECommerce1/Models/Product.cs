namespace ECommerce1.Models
{
    public class Product : BaseEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryID { get; set; } // Foreign Key

        // Navigation Properties
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
