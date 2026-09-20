using CleanTodo.Domain.DTOS;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.Validators
{
   public class RegisterUserValidation : AbstractValidator<RegisterUserDto>
   {
      public RegisterUserValidation()
      {
         RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(200)
            .Matches("^[a-zA-Z0-9_]{3,200}$");

         RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(12)
            .MaximumLength(200)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{12,}$");
      }

   }
}
