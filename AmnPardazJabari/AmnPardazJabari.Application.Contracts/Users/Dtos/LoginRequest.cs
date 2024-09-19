using System.ComponentModel.DataAnnotations;

namespace AmnPardazJabari.Application.Contracts.Users.Dtos;

public class LoginRequest
{
    [Required] public string UserName { get; set; }
    [Required] public string Password { get; set; }
}