using AmnPardazJabari.Application.Contracts.Users.Dtos;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Application.Contracts.Users;

public interface IAdminUserService:IScopeLifeTime
{
    GetUserResponse GetUserById(Guid id);
    void Delete(Guid id);
}