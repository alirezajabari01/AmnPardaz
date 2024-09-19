using AmnPardazJabari.Application.Contracts.Users;
using AmnPardazJabari.Application.Contracts.Users.Dtos;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.Users.Contracts;
using AutoMapper;

namespace AmnPardazJabari.Application.Users;

public class AdminUserService(IUserRepository userRepository, IMapper mapper)
    : IAdminUserService, IScopeLifeTime
{
    public GetUserResponse GetUserById(Guid id)
    {
        var user = userRepository.Find(user => user.Id == id);
        return mapper.Map<GetUserResponse>(user);
    }

    public void Delete(Guid id)
    {
        var user = userRepository.Find(user => user.Id == id) ?? throw new NullReferenceException();
        user.DeletedDate = DateTime.Now;
        userRepository.Update(user);
        userRepository.Save();
    }
}