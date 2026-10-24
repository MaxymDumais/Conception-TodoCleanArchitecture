using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.Interfaces.Gateways
{
   public interface IPirateBrokerGateway
   {
      Task<IList<string>> GetAllPorts();

      Task<bool> SendShip(/*SailingShip*/);
   }
}