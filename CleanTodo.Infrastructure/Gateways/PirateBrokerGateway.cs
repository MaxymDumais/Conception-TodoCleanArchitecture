using Azure;
using CleanTodo.Domain.Interfaces.Gateways;

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
         var response = await _httpClient.GetAsync("api/ping");
         response.EnsureSuccessStatusCode();
         return true;
      }

      public async Task<bool> SendShip()
      {
         return true;
      }
   }
}
