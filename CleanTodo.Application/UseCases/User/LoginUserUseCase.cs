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

      public async Task<UserDto> Execute(LoginUserDto loginUser)
      {
         Domain.Entities.User? user = await _userRepository.FindByInfo(loginUser.Username);
         bool isPasswordValid = PasswordHasher.VerifyPassword(loginUser.Password, user.Password);
         if (user == null || !isPasswordValid)
            throw new NotFoundException(loginUser.Username);
         return new UserDto(user);
      }
   }
}
