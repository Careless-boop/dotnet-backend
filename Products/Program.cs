using Microsoft.EntityFrameworkCore;
using Products.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductsContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(opt => opt
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true));

app.UseAuthorization();

app.MapControllers();

// Explicitly set the URL to listen on port 8080
app.Run("http://0.0.0.0:8080");
