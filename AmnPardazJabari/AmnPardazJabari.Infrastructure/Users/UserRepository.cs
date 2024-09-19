using System.Linq.Expressions;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.Users;
using AmnPardazJabari.Domain.Users.Contracts;
using AmnPardazJabari.Infrastructure.Context;

namespace AmnPardazJabari.Infrastructure.Users;

public class UserRepository:BaseRepository<User>,IUserRepository,IScopeLifeTime
{
    private readonly DatabaseContext _dbContext;

    public UserRepository(DatabaseContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public void Save() => _dbContext.SaveChanges();
}