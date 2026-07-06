using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;
using NorthwindAML.Infrastructure.Data;

namespace NorthwindAML.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NorthwindContext _context;

        public UserRepository(NorthwindContext context)
        {
            _context = context;
        }

        public AppUser? GetByUsername(string username) =>
            _context.AppUsers.FirstOrDefault(u => u.Username == username);

        public void Add(AppUser user)
        {
            _context.AppUsers.Add(user);
            _context.SaveChanges();
        }
    }
}