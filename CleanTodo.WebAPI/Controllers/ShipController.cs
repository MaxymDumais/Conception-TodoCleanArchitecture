using CleanTodo.Application.UseCases.Ship;
using CleanTodo.Domain.DTOS.Ships;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTodo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ShipController(GetAllShipsUseCase getAllShipsUseCase) : ControllerBase
   {
      [Authorize]
      [HttpGet]
      [Route("getShips")]
      public async Task<ActionResult<IEnumerable<ShipDto>>> GetAll()
      {
            var ships = await getAllShipsUseCase.Execute();
            return Ok(ships);
      }
   }
}