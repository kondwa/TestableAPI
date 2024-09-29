using Microsoft.EntityFrameworkCore;
using TestableAPI.Models;
using TestableAPI.Repositories;
using TestableAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrgDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrgDB"));
});


builder.Services.AddScoped(typeof(ICrudRepository<>),typeof(CrudRepository<>));
builder.Services.AddScoped(typeof(ICrudService<>),typeof(CrudService<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
