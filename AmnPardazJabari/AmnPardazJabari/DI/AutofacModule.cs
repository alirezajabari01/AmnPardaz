using AmnPardazJabari.Application;
using AmnPardazJabari.Application.Contracts;
using AmnPardazJabari.Domain;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.Service;
using AmnPardazJabari.Infrastructure;
using Autofac;
using Module = Autofac.Module;

namespace AmnPardazJabari.DI;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

        var domainAssembly = typeof(IDomainLayerMarker).Assembly;
        var domainServiceAssembly = typeof(IDomainServiceLayerMarker).Assembly;
        var infrastructureAssembly = typeof(IInfrastructureLayerMarker).Assembly;
        var applicationContractAssembly = typeof(IApplicationContractLayerMarker).Assembly;
        var applicationAssembly = typeof(IApplicationLayerMarker).Assembly;
        builder
            .RegisterAssemblyTypes
            (
                domainServiceAssembly,
                domainAssembly,
                infrastructureAssembly,
                applicationContractAssembly
                , applicationAssembly
            )
            .AssignableTo<IScopeLifeTime>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        // builder
        //     .RegisterAssemblyTypes(domainAssembly, infrastructureAssembly,applicationContractAssembly)
        //     .AssignableTo<ITransientLifeTime>()
        //     .AsImplementedInterfaces()
        //     .InstancePerDependency();
        //
        // builder
        //     .RegisterAssemblyTypes(domainAssembly, infrastructureAssembly,applicationContractAssembly)
        //     .AssignableTo<ISingletonLifeTime>()
        //     .AsImplementedInterfaces()
        //     .SingleInstance();

        base.Load(builder);
    }
}