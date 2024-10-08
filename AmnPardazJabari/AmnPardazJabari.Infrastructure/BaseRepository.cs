﻿using System.Linq.Expressions;
using AmnPardazJabari.Domain.Abstractions.LifeTimeRegisterations;
using AmnPardazJabari.Domain.Users.Contracts;
using AmnPardazJabari.Infrastructure.Context;
using Xunit;

namespace AmnPardazJabari.Infrastructure;

public class BaseRepository<TEntity>(DatabaseContext dbContext) where TEntity : class, IScopeLifeTime
{
    public IQueryable<TResult> CreatePage<TResult>(IQueryable<TResult> query, int pageNumber, int pageSize)
    {
        pageNumber = pageNumber < 1 ? 1 : pageNumber;
        pageSize = pageSize < 1 ? 10 : pageSize;

        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return dbContext.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        dbContext.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        dbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        dbContext.Set<TEntity>().Update(entity);
    }

    public TEntity? GetById(long id)
    {
        return dbContext.Set<TEntity>().Find(id);
    }

    public List<TEntity> GetAll()
    {
        return dbContext.Set<TEntity>().ToList();
    }

    public TEntity? Find(Expression<Func<TEntity, bool>> predicate)
    {
        return dbContext.Set<TEntity>()
            .FirstOrDefault(predicate);
    }

    public bool IsExist(Expression<Func<TEntity, bool>> predicate)
    {
        return dbContext.Set<TEntity>().Any(predicate);
    }
}