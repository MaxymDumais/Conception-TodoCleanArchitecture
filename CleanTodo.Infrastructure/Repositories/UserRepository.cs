using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Infrastructure.Repositories
{
   public class UserRepository : IUserRepository
   {
      private readonly AppDbContext _context;

      public UserRepository(AppDbContext context) 
      { 
         _context = context;
      }

      public async Task<User> Add(User user)
      {
         EntityEntry<User> newUser = await _context.Users.AddAsync(user); // appelle la méthode AddAsync
         await _context.SaveChangesAsync(); // sauvegarde les changements dans la base de données
         return newUser.Entity; // retourne l'entité ajoutée.
      }

      public async Task<User?> FindByInfo(string username, string password)
      {
         return await _context.Users
             .Where(x => x.Username == username &&  x.Password == password)
             .SingleOrDefaultAsync();
      }
   }
}
