using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCases
{
   public class GetShipUseCase
   {
      private readonly IShipRepository _shipRepository;

      public GetShipUseCase(IShipRepository shipRepository)
      {
         _shipRepository = shipRepository;
      }

      public async Task<ShipDto> Execute(Guid id)
      {
         Domain.Entities.Ship? ship = await _shipRepository.FindById(id);

         if (ship == null)
         {
            throw new NotFoundException(id);
         }
         return new ShipDto(ship);
      }
   }
}
