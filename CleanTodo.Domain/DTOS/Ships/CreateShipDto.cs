using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS.Ships
{
   public class CreateShipDto
   {
      public string Name { get; set; }

      public int GoldCargo { get; set; }

      public string Captain { get; set; }

      public int CrewSize { get; set; }

      public string CreatedBy { get; set; }

      public DateTime CreatedAt { get; set; }

      public DateTime LastModified { get; set; }

      public CreateShipDto(string name, int goldCargo, string captain, int crewSize)
      {
         Name = name;
         GoldCargo = goldCargo;
         Captain = captain;
         CrewSize = crewSize;
      }

      public CreateShipDto(SendShipDto ship)
      {
         Name = ship.Name;
         GoldCargo = ship.GoldCargo;
         Captain = ship.Captain;
         CrewSize = ship.CrewSize;
         CreatedBy = ship.CreatedBy;
         CreatedAt = ship.CreatedAt;
         LastModified = ship.LastModified;
      }
   }
}
