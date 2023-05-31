using System.ComponentModel.DataAnnotations;
namespace PriceBuildCalculate.Models
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
