using System.Data;
using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Domain.Users.Contracts;
using AmnPardazJabari.Domain.Users.ValueObjects;
using AmnPardazJabari.Domain.TodoLists;

namespace AmnPardazJabari.Domain.Users
{
    public class User : BaseEntity<Guid>, IScopeLifeTime
    {
        private User()
        {
        }

        public User(string userName, string password, RoleId roleId,
            IUserNameDuplicateChecker userNameDuplicateChecker)
        {
            CheckUserDuplication(userNameDuplicateChecker, userName);
            UserName = new(userName);
            Password = new(password);
            RoleId = roleId;
        }

        public UserName UserName { get; set; }
        public Password Password { get; set; }
        public RoleId RoleId { get; set; }

        private void CheckUserDuplication(IUserNameDuplicateChecker userNameDuplicateChecker, string userName)
        {
            if (userNameDuplicateChecker.IsUserNameDuplicate(userName)) throw new DuplicateNameException();
        }


        #region OneToMany

        public List<TodoLists.TodoList> TodoLists { get; set; }

        #endregion
    }
}