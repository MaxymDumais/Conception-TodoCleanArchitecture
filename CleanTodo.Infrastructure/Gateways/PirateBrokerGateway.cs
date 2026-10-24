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

         var portList = JsonDocument.Parse(await response.Content.ReadAsStringAsync());

         return portList.RootElement.GetProperty("users").EnumerateArray().Select(u => u.GetString()).ToList();
      }

      public async Task<bool> SendShip()
      {
         return true;
      }
   }
}
