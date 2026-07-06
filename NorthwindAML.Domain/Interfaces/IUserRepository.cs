using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Domain.Interfaces
{
    public interface IUserRepository
    {
        AppUser? GetByUsername(string username);
        void Add(AppUser user);
    }
}
