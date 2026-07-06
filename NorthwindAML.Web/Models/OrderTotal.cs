namespace NorthwindAML.Web.Models
{
    public class OrderTotal
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public decimal Total { get; set; }
    }
}