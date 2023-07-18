namespace ECommerce1.Models
{
    public class Image : BaseEntity
    {
        public int ImageID { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int ProductID { get; set; } // Foreign Key
        public virtual Product Product { get; set; }
    }
}
