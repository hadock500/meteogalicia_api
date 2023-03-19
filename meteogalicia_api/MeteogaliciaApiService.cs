using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace meteogalicia_api
{

    public class MeteogaliciaApiService
    {
        private readonly HttpClient _httpClient;
        private readonly String _url = "https://servizos.meteogalicia.gal";

        private readonly ILogger<MeteogaliciaApiService> _logger;

        public MeteogaliciaApiService(HttpClient httpClient, ILogger<MeteogaliciaApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        /*
            Para el día actual y los dos siguientes:
                Cielo (mañana, tarde, noche)
                Se deberá devolver un string indicando la situación. Por ejemplo: "Despejado", "Cubierto", "Chubasco", "Llovizna"...
                Porcentaje de lluvia (mañana, tarde, noche)
                Temperatura Máxima (tMax)
                Temperatura mínima (tMin)
         */

        private static Prediction PredictionConverter(JToken predictionJson)
        {
            var sky = predictionJson["ceo"]!;
            var rainPercentage = predictionJson["pchoiva"]!;

            var prediction = new Prediction()
            {
                Date = DateTime.Parse(predictionJson["dataPredicion"]!.ToString()),
                Sky = new Sky()
                {
                    Morning =   sky["manha"]!.ToObject<DayClimate>(),
                    Night =     sky["noite"]!.ToObject<NightClimate>(),
                    Afternoon = sky["tarde"]!.ToObject<DayClimate>()
                },
                Rain = new RainPercentage()
                {
                    Morning =   rainPercentage["manha"]!.ToObject<int>(),
                    Night =     rainPercentage["noite"]!.ToObject<int>(),
                    Afternoon = rainPercentage["tarde"]!.ToObject<int>()
                },
                TMax = (int)predictionJson["tMax"]!,
                TMin = (int)predictionJson["tMin"]!,
            };
            return prediction;
        }

        public async Task<List<Prediction>> GetPredictions(int municipalityId)
        {
            List<Prediction> predictions = new();

            var uriBuilder = new UriBuilder(_url)
            {
                Path = "/mgrss/predicion/jsonPredConcellos.action",
                Query = $"idConc={municipalityId}"
            };

            var response = await _httpClient.GetAsync(uriBuilder.Uri);

            // Lanza una excepción HttpRequestException si el código devuelve un código http erróneo.
            response.EnsureSuccessStatusCode();

            var responseContent =
                await response.Content.ReadAsStringAsync()
                ?? throw new IOException("No se ha podido leer la respuesta de Meteogalicia");

            var json =
                JObject.Parse(responseContent)
                ?? throw new IOException("No se ha podido convertir la respuesta de Meteogalicia a JSON");

            var threeDaysAfterToday = DateOnly.FromDateTime(DateTime.Now).AddDays(3);
            var predictionsJson = json["predConcello"]!["listaPredDiaConcello"]!;
            foreach (var value in predictionsJson) {
                var predictionDate = DateOnly.FromDateTime(DateTime.Parse(value["dataPredicion"]!.ToString()));
                if(predictionDate.CompareTo(threeDaysAfterToday) < 0) {
                    predictions.Add(PredictionConverter(value));
                }
            }

            return predictions;
        }
    }

}

