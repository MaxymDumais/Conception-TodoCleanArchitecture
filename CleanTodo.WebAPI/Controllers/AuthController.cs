using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases.User;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CleanTodo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AuthController(LoginUserUseCase loginUserUseCase) : ControllerBase
   {
      [Route("Register")]
      [HttpPost]
      public async Task<IActionResult> Register()
      {
         return Ok("ok");
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
