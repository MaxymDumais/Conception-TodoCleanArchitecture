using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS.Ships
{
   public class UpdateShipDto
   {
      public Guid Id { get; set; }
      public string Name { get; set; }

      public int GoldCargo { get; set; }

      public string Captain { get; set; }

      public int CrewSize { get; set; }

      public UpdateShipDto(Guid id, string name, int goldCargo, string captain, int crewSize)
      {
         Id = id;
         Name = name;
         GoldCargo = goldCargo;
         Captain = captain;
         CrewSize = crewSize;
      }
   }
}
