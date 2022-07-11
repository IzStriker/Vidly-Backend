using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Email required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password required")]
    public string? Password { get; set; }
}