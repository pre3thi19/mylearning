// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.Hosting;

// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () =>
// {
//     var html = "<h1>Environment Variables</h1><ul>";
//     foreach (var key in Environment.GetEnvironmentVariables().Keys)
//     {
//         var k = key?.ToString() ?? "";
//         var val = Environment.GetEnvironmentVariable(k) ?? "";
//         html += $"<li><b>{k}</b>: {val}</li>";
//     }
//     html += "</ul>";
//     return Results.Content(html, "text/html");
// });


// app.Run(); 




using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);

var config = configBuilder.Build();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var html = "<h1>Environment Variables</h1><ul>";
    foreach (var key in Environment.GetEnvironmentVariables().Keys)
    {
        var k = key?.ToString() ?? "";
        var val = Environment.GetEnvironmentVariable(k) ?? "";
        html += $"<li><b>{k}</b>: {val}</li>";
    }
    html += "</ul>";

    // Show the value from appsettings.json or appsettings.Docker.json
    html += $"<h2>AppSettings Environment: {config["Environment"]}</h2>";

    return Results.Content(html, "text/html");
});

app.Run();
