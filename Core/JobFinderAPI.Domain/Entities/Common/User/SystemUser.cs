using JobFinderAPI.Domain.Enums;

namespace JobFinderAPI.Domain.Entities.Common.User
{
    public abstract class SystemUser: BaseEntity
    {
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? EmailVerificationToken { get; set; }
        public bool IsEmailVerified { get; set; }
        public Role Role { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
    }
}
