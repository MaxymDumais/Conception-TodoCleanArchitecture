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
      [Route("test")]
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         return Ok("ok");
      }
   }
}
