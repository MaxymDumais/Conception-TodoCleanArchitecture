using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
   public class DeleteTodoDto
   {
      public Guid Id { get; set; }

      public DeleteTodoDto(Guid id)
      {
         Id = id;
      }
   }
}
