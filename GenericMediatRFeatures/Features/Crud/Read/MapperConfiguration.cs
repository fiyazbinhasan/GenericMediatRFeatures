using AutoMapper;
using GenericMediatRFeatures.Entities;
using GenericMediatRFeatures.ViewModels;

namespace GenericMediatRFeatures.Features.Crud.Read;

public partial class Read
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<WeatherForecast, WeatherForecastModel>(MemberList.Destination)
                .ForMember(d => d.TemperatureF, opts => opts.MapFrom(s => 32 + (int) (s.TemperatureC / 0.5556)));
        }
    }
}
