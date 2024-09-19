using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.Users.Contracts;

namespace AmnPardazJabari.Domain.Service.Users;

public class UserNameDuplicateChecker(IUserRepository userRepository) : IUserNameDuplicateChecker,IScopeLifeTime
{
    public bool IsUserNameDuplicate(string userName)
        => userRepository.IsExist(user => user.UserName.Value == userName);
}