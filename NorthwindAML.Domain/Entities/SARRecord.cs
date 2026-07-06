using System.ComponentModel.DataAnnotations;

namespace NorthwindAML.Domain.Entities
{
    public class SARRecord
    {
        [Key]
        public int SARID { get; set; }
        public string CustomerID { get; set; } = string.Empty;
        public DateTime GeneratedDate { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
    }
}