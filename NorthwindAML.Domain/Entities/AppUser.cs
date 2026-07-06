using System.ComponentModel.DataAnnotations;

namespace NorthwindAML.Domain.Entities
{
    public class AppUser
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Analyst";
    }
}