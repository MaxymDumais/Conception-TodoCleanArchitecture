using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.Interfaces.Gateways
{
   public interface IPirateBrokerGateway
   {
      Task<bool> GetAllPorts();

      Task<bool> SendShip(/*SailingShip*/);
   }
}