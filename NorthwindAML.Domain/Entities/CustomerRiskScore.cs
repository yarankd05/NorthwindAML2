using System.ComponentModel.DataAnnotations;

namespace NorthwindAML.Domain.Entities
{
    public class CustomerRiskScore
    {
        [Key]
        public int RiskScoreID { get; set; }
        public string CustomerID { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}