// https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?source=recommendations&view=aspnetcore-7.0
using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("static-cache", 
        builder => builder.Expire(TimeSpan.FromHours(4)));
    options.AddPolicy("shorttime-cache",
        builder => builder.Expire(TimeSpan.FromSeconds(5)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseOutputCache();

app.MapGet("/", () => "Hello World!");
app.MapGet("/time", () => DateTime.Now.ToString());

app.MapGet("/time/cached", () => DateTime.Now.ToString()).CacheOutput();

app.MapGet("/time/varybyquery", () => DateTime.Now.ToString())
    .CacheOutput(p => p.SetVaryByQuery("culture"));
app.MapGet("/time/varybyheader", () => DateTime.Now.ToString())
    .CacheOutput(p => p.SetVaryByHeader("accept"));

app.MapGet("/time/static-cache", () => DateTime.Now.ToString())
    .CacheOutput(policyName: "static-cache");
app.MapGet("/time/shorttime-cache", () => DateTime.Now.ToString())
    .CacheOutput(policyName: "shorttime-cache");
app.MapGet("/time/shorttime-cache-attribute",
    [OutputCache(PolicyName = "shorttime-cache")]
    () => DateTime.Now.ToString());

app.MapGet("/time/varybyvalue", () => DateTime.Now.ToString())
    .CacheOutput(p => p.VaryByValue(context =>
    new KeyValuePair<string, string>("user", context.Session.GetString("userid") ?? "-")));

app.Run();