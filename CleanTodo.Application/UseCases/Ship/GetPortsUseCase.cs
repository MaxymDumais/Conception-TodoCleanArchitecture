using CleanTodo.Domain.Interfaces.Gateways;

namespace CleanTodo.Application.UseCases.Ship
{
   public class GetPortsUseCase
   {
      private readonly IPirateBrokerGateway _pirateBrokerGateway;

      public GetPortsUseCase(IPirateBrokerGateway pirateBrokerGateway)
      {
         _pirateBrokerGateway = pirateBrokerGateway;
      }

      public async Task<bool> Execute()
      {
         bool x = await _pirateBrokerGateway.GetAllPorts();
         return x;
      }
   }
}
