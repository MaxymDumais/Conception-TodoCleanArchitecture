using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Interfaces.Gateways;
using CleanTodo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CleanTodo.Application.UseCases.Ship
{
   public class GetPortsUseCase
   {
      private readonly IPirateBrokerGateway _pirateBrokerGateway;

      public GetPortsUseCase(IPirateBrokerGateway pirateBrokerGateway)
      {
         _pirateBrokerGateway = pirateBrokerGateway;
      }

      public async Task<string> Execute()
      {
         var ports = await _pirateBrokerGateway.GetAllPorts();
         return ports;
      }
   }
}
