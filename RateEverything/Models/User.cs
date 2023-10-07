using System.ComponentModel.DataAnnotations;

namespace RateEverything.Models
{
    public class User
    {
        /// <summary>
        /// Unique ID for each user
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Public name used for comments
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Email used for creating and logging into account
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password for logging into account
        /// </summary>
        [Required]
        public string Password { get; set; }

    }

    /// <summary>
    /// ViewModel used to create a new member
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User's email
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Email confirmation
        /// </summary>
        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        /// <summary>
        /// User's selected password
        /// </summary>
        [Required]
        [StringLength(75, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Password confirmation
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// ViewModel for loggin in
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Inputted email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Inputted password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
