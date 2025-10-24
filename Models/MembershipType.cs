namespace WebApplication1.Models
{
    public class MembershipType
    {
        public int Id { get; set; } 
        public int SignUpFee { get; set; }
        public string DurationInMonth { get; set; } = string.Empty;
        public int DiscountRate { get; set; }

        public List<Customer>? Customers { get; set; }
    }
}