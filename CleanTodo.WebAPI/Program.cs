// Program.cs
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CleanTodo.Application;
using CleanTodo.Infrastructure;

public class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);

      // Add Authentication services
      builder.Services.AddAuthentication(options =>
      {
         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
         options.TokenValidationParameters = new TokenValidationParameters
         {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-app",
            ValidAudience = "your-app",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey123"))
         };
      });

      // Add Authorization
      builder.Services.AddAuthorization();

      // Add services to the container.
      builder.Services.AddControllers();

      // Add Application Layer
      builder.Services.AddApplication();

      // Add Infrastructure Layer
      builder.Services.AddInfrastructure(builder.Configuration);

      // Add Swagger/OpenAPI
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      app.UseSwagger();
      app.UseSwaggerUI();

      app.UseHttpsRedirection();
      app.UseAuthentication();
      app.UseAuthorization();
      app.MapControllers();
     
      app.Run();
   }
}