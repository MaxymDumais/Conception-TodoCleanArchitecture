using CleanTodo.Domain.Interfaces.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CleanTodo.Infrastructure.Gateways
{
   public class PirateBrokerGateway : IPirateBrokerGateway
   {
      private readonly HttpClient _httpClient;

      public PirateBrokerGateway(HttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<bool> GetAllPorts()
      {
         try
         {
            await _httpClient.GetAsync("/ping");
            return true;
         }
         catch (Exception)
         {
            return false;
         }
      }

      public async Task<bool> SendShip()
      {
         return true;
      }
   }
}
