// https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?source=recommendations&view=aspnetcore-7.0
using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("static-cache",
        builder => builder.Expire(TimeSpan.FromHours(4)));
    options.AddPolicy("shorttime-cache",
        builder => builder.Expire(TimeSpan.FromSeconds(5)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseOutputCache();

// Configure endpoints
app.MapGet("/time", () => CurrentTime());

app.MapGet("/time/cached", () => CurrentTime())
    .CacheOutput();

app.MapGet("/time/cached/varybyquery", () => CurrentTime())
    .CacheOutput(p => p.SetVaryByQuery("culture"));
app.MapGet("/time/cached/varybyheader", () => CurrentTime())
    .CacheOutput(p => p.SetVaryByHeader("accept"));

app.MapGet("/time/cached/policy-static", () => CurrentTime())
    .CacheOutput(policyName: "static-cache");
app.MapGet("/time/cached/policy-shorttime", () => CurrentTime())
    .CacheOutput(policyName: "shorttime-cache");
app.MapGet("/time/cached/attribute",
    [OutputCache(PolicyName = "shorttime-cache")]
    () => CurrentTime());

app.MapGet("/time/cached/varybyvalue", () => CurrentTime())
    .CacheOutput(p => p.VaryByValue(context =>
    new KeyValuePair<string, string>("user", context.Session.GetString("userid") ?? "-")));

app.Run();

static string CurrentTime()
{
    return DateTime.Now.ToLongTimeString();
}