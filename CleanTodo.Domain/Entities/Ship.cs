using CleanTodo.Domain.Enums;

namespace CleanTodo.Domain.Entities
{
   public class Ship
   {
      public Guid Id { get; set; }

      public string Name { get; set; }

      public int GoldCargo { get; set; }

      public string Captain { get; set; }

      public int CrewSize { get; set; }

      public string Status { get; set; }

      public string CreatedBy { get; set; }

      public DateTime CreatedAt { get; set; }

      public DateTime LastModified { get; set; }

      public Ship(string name, int goldCargo, string captain, int crewSize, ShipStatusEnum status)
      {
         Id = Guid.NewGuid();
         Name = name;
         GoldCargo = goldCargo;
         Captain = captain;
         CrewSize = crewSize;
         Status = status.ToString();
         CreatedBy = "Maxym d";
         CreatedAt = DateTime.Now; 
         LastModified = DateTime.Now;
      }

      public Ship() { }
   }
}
