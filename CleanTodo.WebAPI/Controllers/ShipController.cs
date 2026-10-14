using CleanTodo.Application.UseCases.Ship;
using CleanTodo.Application.UseCases.Todo;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.DTOS.Ships;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTodo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ShipController(GetAllShipsUseCase getAllShipsUseCase, CreateShipUseCase createShipUseCase) : ControllerBase
   {
      [Authorize]
      [HttpGet]
      [Route("getShips")]
      public async Task<ActionResult<IEnumerable<ShipDto>>> GetAll()
      {
            var ships = await getAllShipsUseCase.Execute();
            return Ok(ships);
      }

      [Authorize]
      [HttpPost]
      [Route("addShip")]
      public async Task<ActionResult<TodoDto>> Create([FromBody] CreateShipDto createShipDto)
      {
         try
         {
            IList<ShipDto> ships = await getAllShipsUseCase.Execute();
            if (ships.Count >= 8)
               return BadRequest("Le port est plein!! (8 navires maximum). Impossible d'ammarer le navire");

            ShipDto ship = await createShipUseCase.Execute(createShipDto);
            return Ok();
         }
         catch (Exception)
         {

            return BadRequest("Veuillez respecter les critères");
         }
      }
   }
}