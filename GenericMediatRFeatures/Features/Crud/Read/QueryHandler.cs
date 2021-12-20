using AutoMapper;
using GenericMediatRFeatures.Entities;
using GenericMediatRFeatures.ViewModels;
using MediatR;

namespace GenericMediatRFeatures.Features.Crud.Read;

public partial class Read
{
    public class QueryHandler<TEntity, TModel> : IRequestHandler<Query<TModel>, List<TModel>> 
        where TEntity : Entity
        where TModel: ViewModel
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public QueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<List<TModel>> Handle(Query<TModel> request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<TModel>>(await _repository.Read());
        }
    }
}
