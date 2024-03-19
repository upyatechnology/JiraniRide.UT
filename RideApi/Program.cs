using Application.Contracts.Infrastructure;
using Application;
using Infrastructure;
using Infrastructure.Messaging;
using RideApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddSingleton<IKafkaRiderRouteConsumer, KafkaRiderRouteConsumer>();
builder.Services.AddSingleton<IKafkaRideRequestProducer, KafkaDriverRouteRequestProducer>();
builder.Services.AddSingleton<IKafkaRiderRouteProducer, KafkaRiderRouteRequestProducer>(); 
builder.Services.AddSingleton<IKafkaDriverRouteConsumer, KafkaDriverRouteConsumer>();
builder.Services.AddSingleton<KafkaRiderTopicConsumer>();
builder.Services.AddSingleton<KafkaDriverTopicConsumer>();
builder.Services.AddInfrastructureServices(builder.Configuration);
//builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddIdentityServices(builder.Configuration);
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
