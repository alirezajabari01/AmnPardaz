using System.Security.Authentication;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using Microsoft.AspNetCore.Http;
using OnlineGym.Application.Security;

namespace AmnPardazJabari.Application.UserId;

public class UserContext : IUserContext,IScopeLifeTime
{
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
        if (!string.IsNullOrEmpty(token))
        {
            var claimPrinciple = TokenGenerator.ValidateToken(token);
            if (claimPrinciple != null)
            {
                var userId = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userId")?.Value;
                var userName = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userName")?.Value;
                var role = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "role")?.Value;
                UserId = Guid.Parse(userId);
                UserName = userName;
                Role = role;
            }
        }
        else
        {
            //throw new AuthenticationException();
        }
    }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
}