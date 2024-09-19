using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AmnPardazJabari.Application.Contracts.Users.Dtos;

public class RegisterUserRequest
{
    [Required] public string UserName { get; set; }
    [Required] public string Password { get; set; }
}