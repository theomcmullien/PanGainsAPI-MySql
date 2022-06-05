global using System.ComponentModel.DataAnnotations;

namespace PanGainsAPI.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //public byte[]? PasswordHash { get; set; }
        //public byte[]? PasswordSalt { get; set; }
        public string? Title { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Description { get; set; }
        public bool Private { get; set; }
        public bool Notifications { get; set; }
        public int AverageChallengePos { get; set; }
        public string? Type { get; set; }
        public string? Role { get; set; } //JWT Signing Claims
    }
}
