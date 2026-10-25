using CleanTodo.Domain.DTOS.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.Interfaces.Gateways
{
   public interface IPirateBrokerGateway
   {
      Task<List<string>> GetAllPorts();

      Task<bool> SendShip(string destination, SendShipDto sendShipDto);
   }
}