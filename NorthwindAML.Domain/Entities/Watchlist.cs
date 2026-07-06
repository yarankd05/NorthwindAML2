using System.ComponentModel.DataAnnotations;

namespace NorthwindAML.Domain.Entities
{
    public class Watchlist
    {
        [Key]
        public int WatchlistID { get; set; }
        public string FlaggedName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}