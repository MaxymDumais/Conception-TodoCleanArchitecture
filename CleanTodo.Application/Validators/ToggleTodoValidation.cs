using CleanTodo.Domain.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.Validators
{
   public class ToggleTodoValidation : AbstractValidator<ToggleTodoDto>
   {
      public ToggleTodoValidation() 
      {
         RuleFor(x => x.IsChecked)
            .NotNull();
      }  
   }
}
