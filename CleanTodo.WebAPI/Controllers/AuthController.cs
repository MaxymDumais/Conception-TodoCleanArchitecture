using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases.Todo;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CleanTodo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AuthController : ControllerBase
   {
      [Route("Register")]
      [HttpPost]
      public async Task<IActionResult> Register()
      {
         return Ok("ok");
      }

      [Route("Login")]
      [HttpPost]
      public async Task<IActionResult> Login()
      {
         return Ok("ok");
      }
   }
}
