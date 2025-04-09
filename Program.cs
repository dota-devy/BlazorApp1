using BlazorApp1.Components;
using Fido2NetLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Read ServerName from configuration
var serverName = builder.Configuration["AppSettings:ServerName"];

builder.Services.AddSingleton<Fido2>(new Fido2(new Fido2Configuration
{
    ServerDomain = "localhost",
    ServerName = serverName,
    Origins = new HashSet<string> { "https://localhost:5001" },
    TimestampDriftTolerance = TimeSpan.FromMinutes(5).Seconds
}));

var app = builder.Build();

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
