using CleanTodo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
   public class User
   {
      public Guid Id { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }


      public User(Entities.User user)
      {
         Id = user.Id;
         Username = user.Username;
         Password = user.Password;
      }
   }
}
