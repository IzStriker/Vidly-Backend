using System.ComponentModel.DataAnnotations;
using Backend.Models.Annotations;

namespace Backend.Controllers.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "ConfirmPassword is required")]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessage = "FirstName is required")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "DateOfBirth is required")]
    [DateOfBirth(ErrorMessage = "Invalid DateOfBirth")]
    public DateTime DateOfBirth { get; set; }
}