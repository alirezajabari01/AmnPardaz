using AmnPardazJabari.Application.Contracts.Users;
using AmnPardazJabari.Application.Contracts.Users.Dtos;
using AmnPardazJabari.Application.Security;
using AmnPardazJabari.Application.UserId;
using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Filters;
using AmnPardazJabari.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace AmnPardazJabari.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(
        DatabaseContext context,
        IAuthenticationService userService
    )
        : ControllerBase
    {
        [HttpPost]
        public void Register(RegisterUserRequest request) => userService.RegisterUser(request);

        [HttpPost("[action]")]
        public LoginResponse Login(LoginRequest request) => userService.Login(request);
    }
}