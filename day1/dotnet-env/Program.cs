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

var builder = WebApplication.CreateBuilder(args);

// Load JSON configs based on ASPNETCORE_ENVIRONMENT
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); // this ensures docker -e overrides JSON

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

    // Value will come from JSON, or override from docker -e
    var environmentValue = app.Configuration["Environment"] ?? "Not Found";
    html += $"<h2>AppSettings Environment: {environmentValue}</h2>";

    return Results.Content(html, "text/html");
});

app.Run();

