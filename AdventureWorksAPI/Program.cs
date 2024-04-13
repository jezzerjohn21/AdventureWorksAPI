using AdventureWorkPersistence.DataAccess;
using AdventureWorkPersistence.DataAccess.Interface;
using AdventureWorkPersistence.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//setting up the program cs
builder.Services.AddTransient<IAdventureWorksDataAccess, AdventureWorksDataAccess>();

builder.Services.AddDbContext<AdventureWorksDBContext>(opts =>
{
	opts.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDBConnection"));
});



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