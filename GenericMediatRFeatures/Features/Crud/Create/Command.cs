using GenericMediatRFeatures.ViewModels;
using MediatR;

namespace GenericMediatRFeatures.Features.Crud.Create;

public partial class Create
{
    public class Command<TModel> : IRequest where TModel : ViewModel
    {
        public Command(TModel model)
        {
            Model = model;
        }

        public TModel Model { get; }
    }
}
