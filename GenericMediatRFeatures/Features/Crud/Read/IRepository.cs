using GenericMediatRFeatures.Entities;

namespace GenericMediatRFeatures.Features.Crud.Read;

public partial class Read
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> Read();
    }
}