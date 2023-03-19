using Microsoft.AspNetCore.Mvc;

namespace meteogalicia_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ObservacionController : ControllerBase
{

    private readonly ILogger<ObservacionController> _logger;

    private readonly MeteogaliciaApiService _meteogaliciaApiService;

    public ObservacionController(ILogger<ObservacionController> logger, MeteogaliciaApiService externalApiService)
    {
        _logger = logger;
        _meteogaliciaApiService = externalApiService;
    }

    [HttpGet("{id}", Name = "GetPrediction")]
    public async Task<List<Prediction>> Get([FromRoute(Name = "id")] int municipalityId)
    {
        var result = await _meteogaliciaApiService.GetPredictions(municipalityId);

        return result;
    }
}