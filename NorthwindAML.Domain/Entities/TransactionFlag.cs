using System.ComponentModel.DataAnnotations;

namespace NorthwindAML.Domain.Entities
{
    public class TransactionFlag
    {
        [Key]
        public int FlagID { get; set; }
        public int OrderID { get; set; }
        public string CustomerID { get; set; } = string.Empty;
        public string FlagType { get; set; } = string.Empty;
        public DateTime FlaggedDate { get; set; }
    }
}