using CleanTodo.Domain.Entities;

namespace CleanTodo.Domain.Interfaces.Repositories;

public interface ITodoRepository
{
   Task<List<Todo>> GetAll();
   Task<Todo?> FindById(Guid id);
   Task<bool> ToggleCheck(Guid id);
   Task<bool> Delete (Guid id);
   Task<Todo> Add(Todo todo);
}
