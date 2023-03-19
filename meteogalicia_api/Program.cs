using meteogalicia_api;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

/*
    AddTransient    -> Se crea una instancia nueva cada vez que es llamada.
    AddScoped       -> Se reutiliza la misma instancia por cada llamada a la API.
    AddSingleton    -> Se reutiliza siempre la misma instancia.
 */
builder.Services.AddTransient<MeteogaliciaApiService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

