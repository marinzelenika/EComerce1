namespace ECommerce1.Models
{
    public class Category : BaseEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryID { get; set; } // Nullable foreign key

        // Navigation Properties
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> Subcategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
