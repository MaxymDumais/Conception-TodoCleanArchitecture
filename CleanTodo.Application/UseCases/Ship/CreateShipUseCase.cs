using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Enums;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.Ship
{
   public class CreateShipUseCase
   {
      private readonly IShipRepository _shipRepository;

      private readonly IValidator<CreateShipDto> _validator;

      public CreateShipUseCase(IShipRepository shipRepository, IValidator<CreateShipDto> validator)
      {
         _shipRepository = shipRepository;
         _validator = validator;
      }

      public async Task<ShipDto> Execute(CreateShipDto createShipDto)
      {
         ValidationResult validationResult = await _validator.ValidateAsync(createShipDto);
         if (!validationResult.IsValid)
         {
            throw new ValidationException(validationResult.Errors);
         }

         Domain.Entities.Ship newShip = new Domain.Entities.Ship(createShipDto.Name, createShipDto.GoldCargo, createShipDto.Captain, createShipDto.CrewSize, ShipStatusEnum.docked);
         await _shipRepository.Add(newShip);
         return new ShipDto(newShip);
      }
   }
}
