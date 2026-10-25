using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Interfaces.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.Ship
{
   public class SendShipUseCase
   {
      private readonly IPirateBrokerGateway _pirateBrokerGateway;

      public SendShipUseCase(IPirateBrokerGateway pirateBrokerGateway)
      {
         _pirateBrokerGateway = pirateBrokerGateway;
      }

      public async Task<bool> Execute(string destination, SendShipDto sendShipDto)
      {
         var response = await _pirateBrokerGateway.SendShip(destination, sendShipDto);
         return response;
      }
   }
}
