using Azure;
using CleanTodo.Domain.Interfaces.Gateways;
using System.Net.Http.Json;

namespace CleanTodo.Infrastructure.Gateways
{
   public class PirateBrokerGateway : IPirateBrokerGateway
   {
      private readonly HttpClient _httpClient;

      public PirateBrokerGateway(HttpClient httpClient)
      {
         _httpClient = httpClient;
      }


      public async Task<List<string>> GetAllPorts()
      {
         var response = await _httpClient.GetAsync("api/users");
         response.EnsureSuccessStatusCode();
         return await response.Content.ReadFromJsonAsync<List<string>>();
      }

      public async Task<bool> SendShip()
      {
         return true;
      }
   }
}
