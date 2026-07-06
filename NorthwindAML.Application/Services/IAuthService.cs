using NorthwindAML.Application.DTOs;
using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Application.Services
{
    public interface IAuthService
    {
        AppUser? Login(LoginDto dto);
        void Register(RegisterDto dto);
    }
}