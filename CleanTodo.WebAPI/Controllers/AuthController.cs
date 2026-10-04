using Azure.Core;
using CleanTodo.Application.Services;
using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases.User;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CleanTodo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AuthController(JwtService jwtService, LoginUserUseCase loginUserUseCase, RegisterUserUseCase registerUserUseCase) : ControllerBase
   {

      [Route("Register")]
      [HttpPost]
      public async Task<IActionResult> Register(RegisterUserDto registerUser)
      {
         try
         {
            RegisterUserDto newUser = new RegisterUserDto(registerUser.Username, registerUser.Password);
            string confirmation = await registerUserUseCase.Execute(newUser);
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
            UserDto user = new UserDto();
            user = await loginUserUseCase.Execute(username, password);

            var token = jwtService.GenerateToken(1, username);

            Response.Cookies.Append("jwt", token, new CookieOptions
            {
               HttpOnly = true,                  
               Secure = true,                    
               SameSite = SameSiteMode.Strict,     
               Expires = DateTime.UtcNow.AddDays(7)
            });

            return Ok("Connexion réussie, bienvenue " + username);
         }
         catch (NotFoundException)
         {
            return NotFound("Votre username ou votre mot de passe est incorrect...");
         }
      }

      [Route("Logout")]
      [HttpPost]
      public IActionResult Logout()
      {
         try
         {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
               HttpOnly = true,
               Secure = true,
               SameSite = SameSiteMode.None
            });

            return Ok("Déconnexion réussie");
         }
         catch (Exception)
         {

            throw;
         }
      }

   }
}
