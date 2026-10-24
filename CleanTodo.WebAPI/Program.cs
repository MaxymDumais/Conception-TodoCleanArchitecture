// Program.cs
using CleanTodo.Application;
using CleanTodo.Infrastructure;
using CleanTodo.Infrastructure.Data;
using CleanTodo.Infrastructure.Gateways;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Text;

public class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddControllers();

      // Add Application Layer
      builder.Services.AddApplication();

      // Add Infrastructure Layer
      builder.Services.AddInfrastructure(builder.Configuration);

      // Add Swagger/OpenAPI
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      //Variables liées à l'authentification jwt
      var jwtSettings = builder.Configuration.GetSection("JwtSettings");
      var secretKey = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings")["Key"]);

      builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
       options.TokenValidationParameters = new TokenValidationParameters
       {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings["Issuer"],
          ValidAudience = jwtSettings["Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(secretKey)
       };

       options.Events = new JwtBearerEvents
       {
          OnMessageReceived = context =>
          {
             context.Token = context.Request.Cookies["jwt"];
             return Task.CompletedTask;
          }
       };
    });

      builder.Services.AddCors(options =>
      {
         options.AddPolicy("AllowAll", policy =>
         {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
         });
      });

      builder.Services.AddHttpClient<PirateBrokerGateway>(client =>
      {
      client.BaseAddress = new Uri(builder.Configuration.GetSection("PirateBrokerParameters")["BrokerURL"]);
      client.Timeout = TimeSpan.FromSeconds(30);
      client.DefaultRequestHeaders.Add("Accept", "application/json");
      client.DefaultRequestHeaders.Add("x-client-id", builder.Configuration.GetSection("PirateBrokerParameters")["ClientId"]);
      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration.GetSection("PirateBrokerParameters")["AppToken"]);
      });

      builder.Services.AddSwaggerGen(options =>
      {
         options.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanTodo API", Version = "v1" });

         // 1. Définir le schéma de sécurité JWT pour Swagger
         options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
         {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Entrez directement votre token JWT ci-dessous."
         });

         // 2. Appliquer la sécurité globalement à tous les endpoints
         options.AddSecurityRequirement(new OpenApiSecurityRequirement
         {
            {
               new OpenApiSecurityScheme
               {
                  Reference = new OpenApiReference
                  {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                  }
               },
               Array.Empty<string>()
            }
         });
      });


      var app = builder.Build();
      app.UseCors("AllowAll");
      app.UseSwagger();
      app.UseSwaggerUI();

      app.UseHttpsRedirection();

      app.UseAuthentication();
      app.UseAuthorization();

      app.MapControllers();

      app.Run();
   }
}