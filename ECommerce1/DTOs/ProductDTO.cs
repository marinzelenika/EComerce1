namespace ECommerce1.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryID { get; set; }
        public List<ImageDTO> Images { get; set; }
    }
}
