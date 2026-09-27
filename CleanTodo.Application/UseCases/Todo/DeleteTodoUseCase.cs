using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel;

namespace CleanTodo.Application.UseCases.Todo
{
   public class DeleteTodoUseCase
   {
      private readonly ITodoRepository _todoRepository;

      public DeleteTodoUseCase(ITodoRepository todoRepository)
      {
         _todoRepository = todoRepository;
      }

      public async Task Execute(Guid id)
      {
         bool deleted = await _todoRepository.Delete(id);

         if (!deleted)
            throw new NotFoundException(id);
      }
   }
}