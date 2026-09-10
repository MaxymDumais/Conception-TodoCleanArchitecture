using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
   public class CreateTodoDto
   {
      public string Title { get; set; }

      public CreateTodoDto(string title)
      {
         Title = title;
      }
   }
}