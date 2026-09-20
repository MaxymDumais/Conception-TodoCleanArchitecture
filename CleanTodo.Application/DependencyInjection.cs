using CleanTodo.Application.UseCase;
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
      //services.AddScoped<CreateTodoUseCase>();
      //services.AddScoped<DeleteTodoUseCase>();
      services.AddScoped<GetTodoUseCase>();
        services.AddScoped<GetAllTodosUseCase>();
      services.AddScoped<LoginUserUseCase>();
      services.AddScoped<RegisterUserUseCase>();
      services.AddScoped<RegisterUserValidation>();
      //services.AddScoped<ToggleTodoCompleteStatusUseCase>();

      return services;
    }
}