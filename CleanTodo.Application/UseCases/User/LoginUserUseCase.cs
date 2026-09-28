using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCases.User
{
   public class LoginUserUseCase
   {
      private readonly IUserRepository _userRepository;

      public LoginUserUseCase(IUserRepository userRepository)
      {
         _userRepository = userRepository;
      }

      public async Task<UserDto> Execute(string username, string password)
      {
         Domain.Entities.User? user = await _userRepository.FindByInfo(username);
         bool isPasswordValid = PasswordHasher.VerifyPassword(password, user.Password);
         if (user == null || !isPasswordValid)
            throw new NotFoundException(username);
         return new UserDto(user);
      }
   }
}
