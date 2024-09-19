using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;


namespace AmnPardazJabari.Application.UserId;

public interface IUserContext : IScopeLifeTime
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
}