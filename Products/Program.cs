using Microsoft.EntityFrameworkCore;
using Products.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
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

// Enable CORS with a named policy.
app.UseCors("AllowAnyPolicy");

app.UseAuthorization();

app.MapControllers();

// Set up CORS policy
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true));

// Explicitly set the URL to listen on port 8080
app.Run("http://0.0.0.0:8080");
