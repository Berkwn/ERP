using ERPServer.Infrastructure;
using ERPServer.WebAPI.Helper;
using ERPServer.Application;
using DefaultCorsPolicyNugetPackage;
using ERPServer.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddDefaultCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, JwtTokenOptionsSetup>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
  
}




app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ExtensionsMiddleware.CreateFirstUser(app);

app.Run();
