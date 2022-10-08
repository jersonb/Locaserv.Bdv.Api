using Locaserv.Bdv.Api;
using Locaserv.Bdv.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddDbContext<LocaservContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"),
    m => m.MigrationsHistoryTable("__EFMigrationsHistory", "bdv")));

services.AddScoped<ILocaservContext, LocaservContext>();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<LocaservContext>();
    dataContext.Database.Migrate();
}
app.Run();