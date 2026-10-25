using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Enums;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.Ship
{
   public class DockShipUseCase
   {
      private readonly IShipRepository _shipRepository;

      public DockShipUseCase(IShipRepository shipRepository)
      {
         _shipRepository = shipRepository;
      }

      public async Task<ShipDto> Execute(SendShipDto sendShipDto)
      {
         Domain.Entities.Ship newShip = new Domain.Entities.Ship(sendShipDto.Name, sendShipDto.GoldCargo, sendShipDto.Captain, sendShipDto.CrewSize, sendShipDto.CreatedBy, sendShipDto.CreatedAt, sendShipDto.LastModified);
         await _shipRepository.Add(newShip);
         return new ShipDto(newShip);
      }
   }
}
