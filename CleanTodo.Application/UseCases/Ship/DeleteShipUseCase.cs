using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.Ship
{
   public class DeleteShipUseCase
   {
      private readonly IShipRepository _shipRepository;

      public DeleteShipUseCase(IShipRepository shipRepository)
      {
         _shipRepository = shipRepository;
      }

      public async Task Execute(Guid id)
      {
         bool deleted = await _shipRepository.Delete(id);

         if (!deleted)
            throw new NotFoundException(id);
      }
   }
}
