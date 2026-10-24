using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases;
using CleanTodo.Application.UseCases.Ship;
using CleanTodo.Application.UseCases.Todo;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTodo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ShipController(GetAllShipsUseCase getAllShipsUseCase, GetShipUseCase getShipUseCase, CreateShipUseCase createShipUseCase, UpdateShipUseCase updateShipUseCase, DeleteShipUseCase deleteShipUseCase, GetPortsUseCase getPortsUseCase) : ControllerBase
   {
      [Authorize]
      [HttpGet]
      [Route("getShips")]
      public async Task<ActionResult<IEnumerable<ShipDto>>> GetAll()
      { 
         try
         {
            var ships = await getAllShipsUseCase.Execute();
            return Ok(ships);
         }
         catch (Exception)
         {

            return BadRequest("Erreur lors de l'obtention de la liste des navires du port");
         }
      }

      [Authorize]
      [HttpGet("getShip/{id}")] 
      public async Task<IActionResult> Get(Guid id)
      {
         try
         {
            ShipDto ship = await getShipUseCase.Execute(id);
            return Ok(ship);
         }
         catch (NotFoundException)
         {
            return NotFound();
         }
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
            return CreatedAtAction(
             nameof(Get),
             new { id = ship.Id },
             ship);
         }
         catch (Exception)
         {

            return BadRequest("Veuillez respecter les critères");
         }
      }

      [Authorize]
      [HttpPatch]
      [Route("updateShip")]
      public async Task<ActionResult<ShipDto>> Update([FromBody] UpdateShipDto updateShipDto)
      {
         try
         {

            IList<ShipDto> ships = await getAllShipsUseCase.Execute();
            bool isShipExist = false;

            foreach (ShipDto s in ships)
            {
               if (s.Id == updateShipDto.Id)
                  isShipExist = true;
            }

            if (!isShipExist)
               return BadRequest("Veuillez modifier un navire existant");

            ShipDto ship = await updateShipUseCase.Execute(updateShipDto);
            return NoContent();
         }
         catch (Exception)
         {

            return BadRequest("Veuillez respecter les critères");
         }
      }

      [Authorize]
      [HttpDelete("deleteShip/{id}")]
      public async Task<IActionResult> Delete(Guid id)
      {
         try
         {
            await deleteShipUseCase.Execute(id);
            return NoContent();
         }
         catch (NotFoundException)
         {
            return NotFound("Erreur dans la suppression de ce todo");
         }
      }


      [Authorize]
      [HttpGet]
      [Route("getPorts")]
      public async Task<IActionResult> GetPorts()
      {
         bool x = await getPortsUseCase.Execute();
         if (x)
            return Ok(x);
         return BadRequest();
      }
   }
}