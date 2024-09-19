using System.Reflection;
using AmnPardazJabari.Domain;
using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Infrastructure.TodoLists;
using AmnPardazJabari.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AmnPardazJabari.Infrastructure.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var entitiesAssembly = typeof(IEntity).Assembly;
        RegisterAllEntities<IEntity>(modelBuilder,entitiesAssembly);
        AddRestrictDeleteBehaviorConvention(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TodoListEntityTypeConfiguration());
    }

    public static void RegisterAllEntities<BaseType>(ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));

        foreach (Type type in types)
            modelBuilder.Entity(type);
    }

    public static void AddRestrictDeleteBehaviorConvention(ModelBuilder modelBuilder)
    {
        IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (IMutableForeignKey fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }
}