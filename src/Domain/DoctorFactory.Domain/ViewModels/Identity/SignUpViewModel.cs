using System.ComponentModel.DataAnnotations;

namespace DoctorFactory.Domain.ViewModels.Identity;

/// <summary> Signup view model. </summary>
public class SignUpViewModel
{
    [Required(ErrorMessage = "Nume utilizator este obligatoriu")]
    [StringLength(80, MinimumLength = 2)]
    [Display(Name = "Nume utilizator")]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Parola")]
    [MaxLength(100, ErrorMessage = "Lungimea parolei nu poate depasi 100 caractere.")]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    [Display(Name = "Confirmare parola")]
    [MaxLength(100, ErrorMessage = "Lungimea parolei nu poate depasi 100 caractere.")]
    public string PasswordConfirm { get; set; }
}