using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Domain.Users;
using AmnPardazJabari.Domain.Users.Contracts;
using AmnPardazJabari.Infrastructure.Abstractions;

namespace AmnPardazJabari.Infrastructure.Users;

public class UserSeedData(IUserNameDuplicateChecker duplicateChecker, IUserRepository userRepository) : IDataInitializer
{
    private const string Password = "DwN1hMmef9T0+MWVUPj1Bw==ueFdNtrPqXDYkX+KLSWz5WB0tXI=";
    public int Order { get; }

    public void InitializeData()
    {
        if (userRepository.Find(d => d.UserName.Value == "alireza") is null)
        {
            var exist = duplicateChecker.IsUserNameDuplicate("alireza");

            User user = new("alireza", Password, RoleId.Admin, duplicateChecker);

            userRepository.Add(user);
            userRepository.Save();
        }
    }
}