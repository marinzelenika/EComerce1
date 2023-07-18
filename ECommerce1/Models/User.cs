namespace ECommerce1.Models
{
    public class User : BaseEntity
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        // Navigation Property
        public virtual ICollection<Order> Orders { get; set; }
    }
}
