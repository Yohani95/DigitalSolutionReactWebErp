using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ErpApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ErpApiContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ErpApiContext") ?? throw new InvalidOperationException("Connection string 'ErpApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provedor=builder.Services.BuildServiceProvider();
var config=provedor.GetService<IConfiguration>();
builder.Services.AddCors(opciones =>
{
    var frontendUrl = config.GetValue<string>("frontend_url");
    opciones.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
