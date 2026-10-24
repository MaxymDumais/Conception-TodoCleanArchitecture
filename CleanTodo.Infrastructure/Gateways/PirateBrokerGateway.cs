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

      public async Task<IList<string>> GetAllPorts()
      {
         var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/api/users");

         string portList = await response.Content.ReadAsStringAsync();

         List<string> ports = JsonSerializer.Deserialize<List<string>>(portList);

         return ports;
      }

      public async Task<bool> SendShip()
      {
         return true;
      }
   }
}
