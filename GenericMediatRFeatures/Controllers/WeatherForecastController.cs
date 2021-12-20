using GenericMediatRFeatures.Features.Crud.Create;
using GenericMediatRFeatures.Features.Crud.Read;
using GenericMediatRFeatures.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenericMediatRFeatures.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public Task<List<WeatherForecastModel>> Get() => 
        _mediator.Send(new Read.Query<WeatherForecastModel>());

    [HttpPost(Name = "PostWeatherForecast")]
    public async Task Post([FromBody] WeatherForecastModel model) => 
        await _mediator.Send(new Create.Command<WeatherForecastModel>(model));
}