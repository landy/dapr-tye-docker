using ClientApp;
using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDaprClient();

var app = builder.Build();

app.MapGet("/", async (DaprClient daprClient) =>
{
    var result =
        await daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(HttpMethod.Get, "backend", "weatherforecast");
    return result;
});

app.Run();
