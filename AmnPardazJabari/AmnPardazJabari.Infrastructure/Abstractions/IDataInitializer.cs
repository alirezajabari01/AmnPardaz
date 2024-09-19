using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;

namespace AmnPardazJabari.Infrastructure.Abstractions;

public interface IDataInitializer: IScopeLifeTime
{
    public int Order { get; }

    public void InitializeData();
}