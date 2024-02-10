using System.ComponentModel.DataAnnotations;

namespace DoctorFactory.Domain.ViewModels.Identity;

/// <summary> Login view model. </summary>
public class LoginViewModel
{
    [Required]
    [StringLength(80, MinimumLength = 3)]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Login { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 3)]
    [DataType(DataType.Password)]
    [Display(Name = "Parola")]
    public string Password { get; set; }
}