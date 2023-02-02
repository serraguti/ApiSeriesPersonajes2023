using ApiSeriesPersonajes2023.Data;
using ApiSeriesPersonajes2023.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = 
    builder.Configuration.GetConnectionString("sqlseriespersonajes");
builder.Services.AddTransient<RepositorySeries>();
builder.Services.AddDbContext<SeriesContext>
    (options => options.UseSqlServer(connectionString)); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Api Series Personajes 2023",
            Version = "v1"
        });
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiSeriesPersonajes 2023 v1");
    options.RoutePrefix = "";
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
