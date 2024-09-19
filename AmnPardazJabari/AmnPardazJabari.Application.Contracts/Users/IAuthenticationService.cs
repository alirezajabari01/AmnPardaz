using AmnPardazJabari.Application.Contracts.Users.Dtos;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Application.Contracts.Users;

public interface IAuthenticationService : IScopeLifeTime
{
    void RegisterUser(RegisterUserRequest request);
    LoginResponse Login(LoginRequest request);
}