using AmnPardazJabari.Application.Contracts.Users;
using AmnPardazJabari.Application.Contracts.Users.Dtos;
using AmnPardazJabari.Application.Security;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Domain.Users;
using AmnPardazJabari.Domain.Users.Contracts;

namespace AmnPardazJabari.Application.Users;

public class AuthenticationService(IUserRepository userRepository, IUserNameDuplicateChecker checker)
    : IAuthenticationService, IScopeLifeTime
{
    public void RegisterUser(RegisterUserRequest request)
    {
        User user = new(request.UserName, request.Password.Salterhash(), RoleId.User, checker);
        userRepository.Add(user);
        userRepository.Save();
    }

    public LoginResponse Login(LoginRequest request)
    {
        var user = userRepository.Find
        (
            user =>
                user.UserName.Value == request.UserName
                && user.Password.Value == request.Password.Salterhash(
                )
        ) ?? throw new NullReferenceException();

        string token = user.Generate();
        
        return new LoginResponse(token);
    }
}