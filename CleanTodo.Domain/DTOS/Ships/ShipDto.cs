using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS.Ships
{
   public class ShipDto
   {
      public Guid Id { get; set; }

      public string Name { get; set; }

      public int GoldCargo { get; set; }

      public string Captain { get; set; }

      public int CrewSize { get; set; }

      public string Status { get; set; }

      public string CreatedBy { get; set; }

      public DateTime CreatedAt { get; set; }

      public ShipDto() { }

      public ShipDto(Ship ship)
      {
         Id = ship.Id;
         Name = ship.Name;
         GoldCargo = ship.GoldCargo;
         Captain = ship.Captain;
         CrewSize = ship.CrewSize;
         Status = ship.Status;
         CreatedBy = ship.CreatedBy;
         CreatedAt = ship.CreatedAt;
      }
   }
}
