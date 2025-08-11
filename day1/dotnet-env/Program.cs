using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

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
    return Results.Content(html, "text/html");
});


app.Run();
