using CleanTodo.Application.Services;
using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases;
using CleanTodo.Application.UseCases.Ship;
using CleanTodo.Application.UseCases.Todo;
using CleanTodo.Application.UseCases.User;
using CleanTodo.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanTodo.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // cette ligne ajoute les validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      services.AddScoped<CreateTodoUseCase>();
      services.AddScoped<GetTodoUseCase>();
      services.AddScoped<ToggleTodoUseCase>();
      services.AddScoped<DeleteTodoUseCase>();
      services.AddScoped<LoginUserUseCase>();
      services.AddScoped<RegisterUserUseCase>();
      services.AddScoped<RegisterUserValidation>();
      services.AddScoped<JwtService>();
      services.AddScoped<GetAllTodosUseCase>();
      // Dépendances pour les useCases de Ship
      services.AddScoped<GetAllShipsUseCase>();
      services.AddScoped<GetShipUseCase>();
      services.AddScoped<CreateShipUseCase>();
      services.AddScoped<DeleteShipUseCase>();


      services.AddScoped<CreateTodoValidation>();
      //services.AddScoped<ToggleTodoCompleteStatusUseCase>();

      return services;
    }
}