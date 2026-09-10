using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel;

namespace CleanTodo.Application.UseCases.Todo
{
   public class CreateTodoUseCase
   {
      private readonly ITodoRepository _todoRepository;

      private readonly IValidator<CreateTodoDto> _validator;

      public CreateTodoUseCase(ITodoRepository todoRepository, IValidator<CreateTodoDto> validator)
      {
         _todoRepository = todoRepository;
         _validator = validator;
      }

      //public async Task<TodoDto> Execute(CreateTodoDto createTodoDto)
      //{
      //   ValidationResult validationResult = await _validator.ValidateAsync(createTodoDto);
      //   if (!validationResult.IsValid)
      //   {
      //      throw new ValidationException(validationResult.Errors);
      //   }
      //}
   }
}
