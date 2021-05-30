using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Second name")]
        public string SecondName { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}