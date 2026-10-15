using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Infrastructure.Repositories
{
   public class ShipRepository : IShipRepository
   {
      private readonly AppDbContext _context;

      public ShipRepository(AppDbContext context)
      {
         _context = context;
      }

      public async Task<List<Ship>> GetAll()
      {
         return await _context.Ships.ToListAsync();
      }

      public async Task<Ship?> FindById(Guid id)
      {
         return await _context.Ships
             .Where(ship => ship.Id == id)
             .SingleOrDefaultAsync();
      }

      public async Task<Ship> Add(Ship ship)
      {
         EntityEntry<Ship> newShip = await _context.Ships.AddAsync(ship);
         await _context.SaveChangesAsync();
         return newShip.Entity;
      }

      public async Task<bool> Update(Ship ship)
      {
         int update = await _context.Ships
        .Where(s => s.Id == ship.Id)
        .ExecuteUpdateAsync(x => x
            .SetProperty(s => s.Name, s => ship.Name)
            .SetProperty(s => s.GoldCargo, s => ship.GoldCargo)
            .SetProperty(s => s.Captain, s => ship.Captain)
            .SetProperty(s => s.CrewSize, s => ship.CrewSize)
            .SetProperty(s => s.LastModified, s => DateTime.Now));

         if (update > 0)
            return true;
         return false;
      }

      public async Task<bool> Delete(Guid id)
      {
         int isShipDeleted = await _context.Ships
           .Where(s => s.Id == id)
           .ExecuteDeleteAsync();

         if (isShipDeleted > 0)
            return true;
         return false;
      }
   }
}
