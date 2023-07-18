namespace ECommerce1.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public Guid UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
