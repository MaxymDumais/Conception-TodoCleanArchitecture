using CleanTodo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.Interfaces.Repositories
{
   public interface IShipRepository
   {
      Task<List<Ship>> GetAll();
      Task<Ship?> FindById(Guid id);
      Task<Ship> Add(Ship ship);
      Task<bool> Update(Ship ship);
      Task<bool> Delete(Guid id);
   }
}
