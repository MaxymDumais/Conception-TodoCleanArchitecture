using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.Todo
{
   public class ToggleTodoUseCase
   {
      private readonly ITodoRepository _todoRepository;
      private readonly IValidator<CreateTodoDto> _validator;
      public ToggleTodoUseCase(ITodoRepository todoRepository, IValidator<CreateTodoDto> validator)
      {
         _todoRepository = todoRepository;
         _validator = validator;
      }

      public async Task Execute(Guid id)
      {
         bool isChecked = await _todoRepository.ToggleCheck(id);
      }
   }
}
