using CleanTodo.Domain.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.User
{
   
   public class RegisterUserUseCase
   {
      private readonly IValidator<RegisterUserUseCase> _validator;
   }

}
