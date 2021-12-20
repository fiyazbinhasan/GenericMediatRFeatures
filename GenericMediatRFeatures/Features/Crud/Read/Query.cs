using GenericMediatRFeatures.ViewModels;
using MediatR;

namespace GenericMediatRFeatures.Features.Crud.Read;

public partial class Read
{
    public record Query<TModel> : IRequest<List<TModel>> where TModel : ViewModel { }
}
