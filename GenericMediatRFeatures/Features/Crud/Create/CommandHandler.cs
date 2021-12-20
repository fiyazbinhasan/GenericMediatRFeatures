using AutoMapper;
using GenericMediatRFeatures.Entities;
using GenericMediatRFeatures.ViewModels;
using MediatR;

namespace GenericMediatRFeatures.Features.Crud.Create;

public partial class Create
{
    public class CommandHandler<TEntity, TModel> : AsyncRequestHandler<Command<TModel>> 
        where TEntity : Entity
        where TModel: ViewModel
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public CommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        protected override Task Handle(Command<TModel> request, CancellationToken cancellationToken)
        {
            _repository.Create(_mapper.Map<TEntity>(request.Model));
            return Task.CompletedTask;
        }   
    }
}