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
            await _httpClient.GetAsync("/ping");
            return true;
      }

      public async Task<bool> SendShip()
      {
         return true;
      }
   }
}
