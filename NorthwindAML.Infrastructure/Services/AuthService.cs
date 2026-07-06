using NorthwindAML.Application.DTOs;
using NorthwindAML.Application.Services;
using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;

namespace NorthwindAML.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public AppUser? Login(LoginDto dto)
        {
            var user = _userRepo.GetByUsername(dto.Username);
            if (user == null) return null;

            bool valid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            return valid ? user : null;
        }

        public void Register(RegisterDto dto)
        {
            var user = new AppUser
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };
            _userRepo.Add(user);
        }
    }
}