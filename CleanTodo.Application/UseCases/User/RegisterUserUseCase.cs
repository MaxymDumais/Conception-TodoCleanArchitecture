using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Application.UseCases.User
{
   
   public class RegisterUserUseCase
   {
      private readonly IUserRepository _userRepository;
      private readonly IValidator<RegisterUserDto> _validator;

      public RegisterUserUseCase(IUserRepository userRepository, IValidator<RegisterUserDto> validator)
      {
         _userRepository = userRepository;
         _validator = validator;
      }

      public async Task<string> Execute(RegisterUserDto registerUserDto)
      {
         ValidationResult validationResult = await _validator.ValidateAsync(registerUserDto);
         if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
         else if (_userRepository.FindByInfo(registerUserDto.Username, registerUserDto.Password) != null)
            throw new Exception("Erreur lors de la création du compte");
         await _userRepository.Add(new Domain.Entities.User(registerUserDto.Username, registerUserDto.Password));
         return "Compte créé!";
      }
   }

}
