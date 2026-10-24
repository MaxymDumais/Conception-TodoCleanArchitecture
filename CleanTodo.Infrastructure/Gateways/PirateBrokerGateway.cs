using CleanTodo.Domain.Interfaces.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Infrastructure.Gateways
{
   public class PirateBrokerGateway : IPirateBrokerGateway
   {
      public async Task<List<string>> GetAllPorts()
      {
         return new List<string>();
      }

      public async Task<bool> SendShip()
      {
         return true;
      }
   }
}
