using CleanTodo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.Interfaces.Repositories
{
   public interface IUserRepository
   {
      Task<User?> FindByInfo(string name, string password);

      Task<User> Add(User user);
   }
}
