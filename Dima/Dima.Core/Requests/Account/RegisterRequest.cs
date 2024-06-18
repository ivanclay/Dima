using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Account;

public class RegisterRequest : RequestBase
{
    [Required(ErrorMessage = "E-mail")]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Invalid password")]
    public string Password { get; set; } = string.Empty;
}
