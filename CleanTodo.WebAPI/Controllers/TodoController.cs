using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases.Todo;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TodoController(GetAllTodosUseCase getAllUseCase, GetTodoUseCase getTodoUseCase, CreateTodoUseCase createTodoUseCase, DeleteTodoUseCase deleteTodoUseCase, ToggleTodoUseCase toggleTodoUseCase) : ControllerBase
{
   [Authorize]
   [HttpGet]
   [Route("getTodos")]
   public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
   {
      var todos = await getAllUseCase.Execute();
      return Ok(todos);
   }

   //Cadeau! pour le create. On utilise un CreatedAtAction qui retourne un code http 201 et un header location avec l'url du nouvel élément créé.
   [Authorize]
   [HttpPost]
   [Route("AddTodo")]
   public async Task<ActionResult<TodoDto>> Create([FromBody] CreateTodoDto createTodoDto)
   {
      try
      {
         TodoDto todo = await createTodoUseCase.Execute(createTodoDto);

         return CreatedAtAction(
             nameof(Get),
             new { id = todo.Id },
             todo);
      }
      catch (Exception)
      {

         return BadRequest("Veuillez respecter les critères");
      }
   }

   [Authorize]
   [HttpGet("getTodo/{id}")] // /api/todo/ton_id
   public async Task<IActionResult> Get(Guid id)
   {
      try
      {
         TodoDto todo = await getTodoUseCase.Execute(id);
         return Ok(todo);
      }
      catch (NotFoundException)
      {
         return NotFound();
      }
   }

   [Authorize]
   [HttpPatch("toggleTodo/{id}")] // /api/todo/ton_id
   public async Task<IActionResult> Toggle(Guid id)
   {
      try
      {
         await toggleTodoUseCase.Execute(id);
         return Ok("Modification réussite avec succès");
      }
      catch (NotFoundException)
      {
         return NotFound();
      }
   }

   // Pour le delete et le update, tu peux retourn un noContent (http 204) qui dit :"Ça fonctionné, je n'ai rien à te retourner"
   //return NoContent();
   [Authorize]
   [HttpDelete("deleteTodo/{id}")] // /api/todo/ton_id
   public async Task<IActionResult> Delete(Guid id)
   {
      try
      {
         await deleteTodoUseCase.Execute(id);
         return NoContent();
      }
      catch (NotFoundException)
      {
         return NotFound("Erreur dans la suppression de ce todo");
      }
   }
}
