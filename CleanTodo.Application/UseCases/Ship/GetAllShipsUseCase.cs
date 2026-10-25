using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.Ship
{
   public class GetAllShipsUseCase
   {
      private readonly IShipRepository _shipRepository;

      public GetAllShipsUseCase(IShipRepository shipRepository)
      {
         _shipRepository = shipRepository;
      }

      public async Task<List<ShipDto>> Execute()
      {
         var ships = await _shipRepository.GetAll();
         return ships.Select(s => new ShipDto(s)).ToList();
      }
   }
}
