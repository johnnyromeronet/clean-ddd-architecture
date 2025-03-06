using Clean.DDD.Architecture.Application.Registration;
using Clean.DDD.Architecture.Business.Registration;
using Clean.DDD.Architecture.Infrastructure.Registration;
using Clean.DDD.Architecture.WebAPI.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddBusinessServices();

builder.Services.AddSwaggerServices();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.AddSwaggerApp();
app.MapControllers();

app.Run();
