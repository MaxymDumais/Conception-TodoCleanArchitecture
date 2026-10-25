using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS.Ships
{
   public class SendShipDto
   {
      public string Name { get; set; }

      public int GoldCargo { get; set; }

      public string Captain { get; set; }

      public int CrewSize { get; set; }

      public string Status { get; set; }

      public string CreatedBy { get; set; }

      public DateTime CreatedAt { get; set; }

      public DateTime LastModified { get; set; }


      public SendShipDto(string name, int goldCargo, string captain, int crewSize, string createdBy, DateTime createdAt)
      {
         Name = name;
         GoldCargo = goldCargo;
         Captain = captain;
         CrewSize = crewSize;
         Status = "sailing";
         CreatedBy = createdBy;
         CreatedAt = createdAt;
         LastModified = DateTime.Now;
      }
   }
}