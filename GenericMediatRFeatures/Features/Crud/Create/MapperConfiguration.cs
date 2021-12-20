using AutoMapper;
using GenericMediatRFeatures.Entities;
using GenericMediatRFeatures.ViewModels;

namespace GenericMediatRFeatures.Features.Crud.Create;

public partial class Create
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<WeatherForecastModel, WeatherForecast>(MemberList.Destination);
        }
    }
}
