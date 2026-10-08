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
   [Route("api/")]
   public class PingController() : ControllerBase
   {

      [Route("ping")]
      [HttpGet]
      public async Task<IActionResult> Ping()
      {
         try
         {
            return Ok("pong");
         }
         catch (Exception)
         {
            return NotFound();
         }
      }
   }
}
