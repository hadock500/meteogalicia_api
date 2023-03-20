using meteogalicia_api.Exceptions;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Prediction>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> Get([FromRoute(Name = "id")] int municipalityId)
    {
        try
        {
            var result = await _meteogaliciaApiService.GetPredictions(municipalityId);

            return Ok(result);
        }
        catch (InstanceNotFoundException ex)
        {
            return NotFound(ex);
        }
        catch (IOException ex)
        {
            return StatusCode(503, ex);
        }
    }
}