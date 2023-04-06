// https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?source=recommendations&view=aspnetcore-7.0
using Microsoft.AspNetCore.OutputCaching;

// App services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("10-seconds-per-query", cachePolicy => cachePolicy
        .Expire(TimeSpan.FromSeconds(10))
        .SetVaryByQuery("queryKey"));
});
var app = builder.Build();

// HTTP request pipeline
app.UseHttpsRedirection();
app.UseOutputCache();

// Model
static string CurrentTime()
{
    return DateTime.Now.ToLongTimeString();
}

// Endpoints
app.MapGet("/time", () => CurrentTime());

app.MapGet("/time/cache", () => CurrentTime()).CacheOutput();

app.MapGet("/time/cache-3-seconds", () => CurrentTime())
    .CacheOutput(option => option.Expire(TimeSpan.FromSeconds(3)));

app.MapGet("/time/cache-per-query", () => CurrentTime())
    .CacheOutput(option => option.SetVaryByQuery("queryKey"));

app.MapGet("/time/cache-per-policy", () => CurrentTime())
    .CacheOutput(policyName: "10-seconds-per-query");

app.MapGet("/time/cache-per-userid", () => CurrentTime())
    .CacheOutput(p => p.VaryByValue(context =>
    new KeyValuePair<string, string>("user", context.Session.GetString("userid") ?? "-")));

app.Run();

// Output cache attribute for "non-minimal API":
// [OutputCache(PolicyName = "3-seconds-per-query")]