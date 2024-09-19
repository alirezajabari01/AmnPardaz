using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Domain.Users.Contracts;

public interface IUserNameDuplicateChecker : IScopeLifeTime
{
    bool IsUserNameDuplicate(string userName);
}