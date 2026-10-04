using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
   public class LoginUserDto
   {
      public string Username { get; set; }
      public string Password { get; set; }

      public LoginUserDto(string username, string password)
      {
         Username = username;
         Password = password;
      }
   }
}