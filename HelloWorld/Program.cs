using HelloWorld.Core.Application.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connStr = builder.Configuration.GetConnectionString("Default")
              ?? builder.Configuration["ConnectionStrings:Default"];
if (string.IsNullOrEmpty(connStr))
{
    throw new InvalidOperationException("Connection string 'Default' not found in configuration.");
}

builder.Services.AddSingleton<INamesRepository>(_ => new NamesRepository(connStr));

var app = builder.Build();

// Ensure DB table exists before serving requests
using (var scope = app.Services.CreateScope())
{
    var repo = scope.ServiceProvider.GetRequiredService<INamesRepository>();
    await repo.InitializeAsync();
}

app.UseStaticFiles();
app.MapRazorPages();
app.Run();