namespace ECommerce1.DTOs
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryID { get; set; }
        public List<CategoryDTO> Subcategories { get; set; }
        public List<ProductDTO> Products { get; set; }

    }
}
