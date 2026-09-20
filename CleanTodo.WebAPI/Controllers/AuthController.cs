using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases.User;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CleanTodo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AuthController(LoginUserUseCase loginUserUseCase, RegisterUserUseCase registerUserUseCase) : ControllerBase
   {
      [Route("Register")]
      [HttpPost]
      public async Task<IActionResult> Register(RegisterUserDto registerUser)
      {
         try
         {
            string confirmation = await registerUserUseCase.Execute(registerUser);
            return Ok(confirmation);
         }
         catch (Exception)
         {
            return NotFound("Erreur lors de la création du compte");
         }
      }

      [Route("Login")]
      [HttpPost]
      public async Task<IActionResult> Login(string username, string password)
      {
         try
         {
            Domain.DTOS.User user = await loginUserUseCase.Execute(username, password);
            return Ok("Connexion réussie!! Bienvenue " + username + "!!");
         }
         catch (NotFoundException)
         {
            return NotFound("Votre username ou votre mot de passe est incorrect...");
         }
      }
   }
}
