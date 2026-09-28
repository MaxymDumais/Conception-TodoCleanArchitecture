using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
   public class ToggleTodoDto
   {
      public bool IsChecked { get; set; }

      public ToggleTodoDto(bool isChecked)
      {
         IsChecked = isChecked;
      }
   }
}
