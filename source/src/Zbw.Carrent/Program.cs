using Microsoft.EntityFrameworkCore;

using Zbw.Carrent.Context;
using Zbw.Carrent.CarManagement.Domain;
using Zbw.Carrent.CustomerManagement.Domain;
using Zbw.Carrent.ReservationManagement.Domain;
using Zbw.Carrent.CarManagement.Infrastructure.Persistence;
using Zbw.Carrent.CustomerManagement.Infrastructure.Persistence;
using Zbw.Carrent.ReservationManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarrentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZbwCarrentContext")));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IRentalContractRepository, RentalContractRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
