using Adapters.Product.Adapters;
using Adapters.Shared.Configuration;
using Adapters.Shared.Database.InMemory;
using Application.Product.Contracts;
using Application.Product.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<InMemoryDbContext>(config =>{
    config.UseInMemoryDatabase(databaseName: "ProductDb");
});

builder.Services.AddTransient<IProductPersistence, ProductAdapter>();

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
