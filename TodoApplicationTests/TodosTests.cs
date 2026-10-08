//using CleanTodo.Application.UseCase;
//using CleanTodo.Application.UseCases.Todo;
//using CleanTodo.Application.UseCases.User;
//using CleanTodo.Application.Validators;
//using CleanTodo.Domain.DTOS;
//using CleanTodo.Domain.Entities;
//using CleanTodo.Domain.Exceptions;
//using CleanTodo.Domain.Interfaces.Repositories;
//using FluentValidation;
//using Moq;

//namespace TodoApplicationTests;

//public class TodosTests
//{
//   private Mock<ITodoRepository> _todoRepositoryMock;
//   private CreateTodoUseCase _createTodoUseCase;
//   private GetTodoUseCase _getTodoUseCase;
//   private DeleteTodoUseCase _deleteTodoUseCase;
//   private GetAllTodosUseCase _getAllTodosUseCase;
//   //private ToggleTodoCompleteStatusUseCase _toggleTodoCompleteStatusUseCase;
//   private IValidator<CreateTodoDto> _createTodoValidator;

//   private Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
//   private RegisterUserUseCase _registerUserUseCase;
//   private LoginUserUseCase _loginUserUseCase;
//   private IValidator<RegisterUserDto> _registerUserValidator = new RegisterUserValidation();

//   Todo todo1 = new Todo { Id = Guid.NewGuid(), Text = "Test Todo 1" };
//   Todo todo2 = new Todo { Id = Guid.NewGuid(), Text = "Test Todo 2" };

//   User user1 = new User("George", "ABC123def!!!");


//   [SetUp]
//   public void Setup()
//   {
//      _createTodoValidator = new CreateTodoValidation();
//      _todoRepositoryMock = new Mock<ITodoRepository>();
//      _createTodoUseCase = new CreateTodoUseCase(_todoRepositoryMock.Object, _createTodoValidator);
//      _getTodoUseCase = new GetTodoUseCase(_todoRepositoryMock.Object);
//      _deleteTodoUseCase = new DeleteTodoUseCase(_todoRepositoryMock.Object);
//      _getAllTodosUseCase = new GetAllTodosUseCase(_todoRepositoryMock.Object);
//      //_toggleTodoCompleteStatusUseCase = new ToggleTodoCompleteStatusUseCase(_todoRepositoryMock.Object);



//      // Arrange
//      _todoRepositoryMock.Setup(repo => repo.Add(It.IsAny<Todo>())).ReturnsAsync(todo1);
//      _todoRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Guid>()));
//      //_todoRepositoryMock.Setup(repo => repo.ToggleCompleteStatus(It.IsAny<Guid>()));
//      _todoRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Todo> { todo1, todo2 });
//      _todoRepositoryMock.Setup(repo => repo.FindById(It.Is<Guid>(id => id == todo1.Id))).ReturnsAsync(todo1);







//      _userRepository.Setup(repo => repo.Add(It.IsAny<User>())).ReturnsAsync(user1);
//      _userRepository.Setup(repo => repo.FindByInfo(It.Is<string>(username => username == user1.Username))).ReturnsAsync(user1);

//      _registerUserUseCase = new RegisterUserUseCase(_userRepository.Object, _registerUserValidator);
//      _loginUserUseCase = new LoginUserUseCase(_userRepository.Object);
//      }

//   [Test]
//   public async Task RegisterUser_ReturnCreatedUser()
//   {
//      RegisterUserDto register = new RegisterUserDto("Marc", "ABC123def!!!");
//      await _registerUserUseCase.Execute(register);
//      var result = await _loginUserUseCase.Execute(register.Username, register.Password);

//      Assert.AreEqual(register.Username, result.Username);
//   }

   //[Test]
   //public async Task CreateTodo_ShouldReturnCreatedTodo()
   //{
   //   // Arrange
   //   CreateTodoDto createTodoDto = new CreateTodoDto { Title = "Test Todo" };
   //   // Act
   //   var result = await _createTodoUseCase.Execute(createTodoDto);

   //   // Assert
   //   Assert.That(todo1.Id == result.Id, "Todo is returned");
   //   Assert.That(todo1.Text == result.Title, "Same text");
   //}

   //[Test]
   //public async Task GetTodo_ShouldReturnTodo()
   //{
   //   // Arrange
   //   CreateTodoDto createTodoDto = new CreateTodoDto { Title = "Test Todo" };
   //   // Act
   //   var result = await _getTodoUseCase.Execute(todo1.Id);

   //   // Assert
   //   Assert.That(todo1.Id == result.Id, "Todo is returned");
   //   Assert.That(todo1.Text == result.Title, "Same text");
   //}

   //[Test]
   //public async Task DeleteTodo_ShouldCallRepositoryDelete()
   //{
   //   // Act
   //   await _deleteTodoUseCase.Execute(todo1.Id);

   //   // Assert
   //   _todoRepositoryMock.Verify(repo => repo.Delete(todo1.Id), Times.Once);
   //}

   //[Test]
   //public async Task GetAllTodos_ShouldReturnAllTodos()
   //{
   //   // Act
   //   var result = await _getAllTodosUseCase.Execute();

   //   // Assert
   //   Assert.That(result.Count == 2, "Got 2 todos");
   //   Assert.That(todo1.Id == result[0].Id, "Both todos are returned");
   //   Assert.That(todo2.Id == result[1].Id, "Both todos are returned");
   //}

   //[Test]
   //public async Task ToggleTodoCompleteStatus_ShouldCallRepositoryToggleCompleteStatus()
   //{
   //   // Act
   //   await _toggleTodoCompleteStatusUseCase.Execute(todo1.Id);

   //   // Assert
   //   _todoRepositoryMock.Verify(repo => repo.ToggleCompleteStatus(todo1.Id), Times.Once);
   //}

   //[Test]
   //public async Task DelitingAMissingTodo_ShouldThrowAnError()
   //{
   //   Guid idOfAFakeTodo = Guid.NewGuid();
   //   // Act

   //   // Assert
   //   Assert.ThrowsAsync<NotFoundException>(async () => await _toggleTodoCompleteStatusUseCase.Execute(idOfAFakeTodo));
   //   _todoRepositoryMock.Verify(repo => repo.FindById(idOfAFakeTodo), Times.Once);
   //}
//}