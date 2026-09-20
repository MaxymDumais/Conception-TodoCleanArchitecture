using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
   public class RegisterUserDto
   {
      public string Username { get; set; }
      public string Password { get; set; }

      public RegisterUserDto(string username, string password)
      {
         Username = username;
         Password = password; 
      }
   }
}
