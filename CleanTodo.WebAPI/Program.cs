
// Program.cs
using CleanTodo.Application;
using CleanTodo.Infrastructure;

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

      var app = builder.Build();

      app.UseSwagger();
      app.UseSwaggerUI();

      app.UseHttpsRedirection();
      app.UseAuthorization();
      app.MapControllers();

      app.Run();
   }
}