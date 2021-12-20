using GenericMediatRFeatures.Data;
using GenericMediatRFeatures.Entities;
using GenericMediatRFeatures.Features.Crud.Create;
using GenericMediatRFeatures.Features.Crud.Read;
using Microsoft.EntityFrameworkCore;

namespace GenericMediatRFeatures.Repositories;

public class GenericRepository<TEntity> : 
    Create.IRepository<TEntity>,
    Read.IRepository<TEntity> 
    where TEntity : Entity
{
    private readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task Create(TEntity entity)
    {
        _dbContext.Set<TEntity>().AddAsync(entity);
        return _dbContext.SaveChangesAsync();
    }

    public Task<List<TEntity>> Read()
    {
        return _dbContext.Set<TEntity>().ToListAsync();
    }
}