using GenericMediatRFeatures.Entities;

namespace GenericMediatRFeatures.Features.Crud.Create;

public partial class Create
{
    public interface IRepository<in TEntity> where TEntity : Entity
    {
        Task Create(TEntity entity);
    }
}