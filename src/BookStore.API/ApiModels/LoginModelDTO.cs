using System.ComponentModel.DataAnnotations;

namespace BookStore.API.ApiModels
{
    public class LoginModelDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}