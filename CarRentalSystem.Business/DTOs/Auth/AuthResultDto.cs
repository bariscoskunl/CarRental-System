
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.DTOs.Auth
{
    public enum UserType
    {
        Customer,
        Company
    }
    public class AuthResultDto
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string? ProfileImageUrl { get; set; }

        public static AuthResultDto Fail(string message)
            => new AuthResultDto { Success = false, ErrorMessage = message };

        public static AuthResultDto SuccessResult(int id, UserType type, string email, string displayName, string? profileImage = null)
            => new AuthResultDto
            {
                Success = true,
                UserId = id,
                UserType = type,
                Email = email,
                DisplayName = displayName,
                ProfileImageUrl = profileImage
            };
    }

}
