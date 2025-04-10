using BlazorApp1.Components;
using BlazorApp1.Services;
using Fido2NetLib;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Read secrets from Secrets Manager
builder.Configuration.AddUserSecrets<Program>();

// Read ServerName from configuration
var serverName = builder.Configuration["AppSettings:ServerName"];

builder.Services.AddSingleton<Fido2>(new Fido2(new Fido2Configuration
{
    ServerDomain = "localhost",
    ServerName = serverName,
    Origins = new HashSet<string> { "https://localhost:5001" },
    TimestampDriftTolerance = TimeSpan.FromMinutes(5).Seconds
}));

// Configure MongoDB settings from Secrets Manager
builder.Services.Configure<MongoDbSettings>(options =>
{
    options.ConnectionString = builder.Configuration["MongoDB:ConnectionString"]
        ?? Environment.GetEnvironmentVariable("MongoDB_ConnectionString")
        ?? throw new InvalidOperationException("MongoDB:ConnectionString is not configured.");
    options.DatabaseName = builder.Configuration["MongoDB:DatabaseName"]
        ?? Environment.GetEnvironmentVariable("MongoDB_DatabaseName")
        ?? throw new InvalidOperationException("MongoDB:DatabaseName is not configured.");
});

// Register MongoDbService
builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();

// Test MongoDB connection on startup
if (app.Environment.IsDevelopment())
{
    var mongoDbService = app.Services.GetRequiredService<MongoDbService>();
    Console.WriteLine("Connected to MongoDB database.");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
