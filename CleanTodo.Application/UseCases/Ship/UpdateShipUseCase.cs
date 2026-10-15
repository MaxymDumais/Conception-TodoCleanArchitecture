using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Enums;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace CleanTodo.Application.UseCases.Ship
{
   public class UpdateShipUseCase
   {
      private readonly IShipRepository _shipRepository;
      private readonly IValidator<UpdateShipDto> _validator;

      public UpdateShipUseCase(IShipRepository shipRepository, IValidator<UpdateShipDto> validator)
      {
         _shipRepository = shipRepository;
         _validator = validator;
      }

      public async Task<ShipDto> Execute(UpdateShipDto updateShipDto)
      {
         ValidationResult validationResult = await _validator.ValidateAsync(updateShipDto);
         if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

         Domain.Entities.Ship updatedShip = new Domain.Entities.Ship(updateShipDto.Id, updateShipDto.Name, updateShipDto.GoldCargo, updateShipDto.Captain, updateShipDto.CrewSize, ShipStatusEnum.docked);
         await _shipRepository.Update(updatedShip);
         return new ShipDto(updatedShip);
      }
   }
}
