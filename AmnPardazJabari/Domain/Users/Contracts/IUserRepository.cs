using System.Linq.Expressions;
using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Domain.Users.Contracts;

public interface IUserRepository : IRepository,IScopeLifeTime
{
    public bool IsExist(Expression<Func<User, bool>> predicate);
    public void Add(User user);
    public void Delete(User user);
    public void Save();
    public void Update(User user);
    public User? GetById(long id);
    public User? Find(Expression<Func<User, bool>> predicate);
}