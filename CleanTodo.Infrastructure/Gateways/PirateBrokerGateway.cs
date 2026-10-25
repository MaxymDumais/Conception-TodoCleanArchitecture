using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Interfaces.Gateways;
using System.Net.Http.Json;
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


      public async Task<List<string>> GetAllPorts()
      {
         var response = await _httpClient.GetAsync("api/users");
         response.EnsureSuccessStatusCode();

         var portList = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());

         return portList.RootElement.GetProperty("users").Deserialize<List<string>>();
      }

      public async Task<bool> SendShip(string destination, SendShipDto sendShipDto)
      {
         var response = await _httpClient.PostAsJsonAsync("api/ship/sail/" + destination, sendShipDto);
         return true;
      }
   }
}
