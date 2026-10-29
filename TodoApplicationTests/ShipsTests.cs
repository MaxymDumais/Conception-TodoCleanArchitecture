using CleanTodo.Application.UseCase;
using CleanTodo.Application.UseCases;
using CleanTodo.Application.UseCases.Ship;
using CleanTodo.Application.Validators.Ships;
using CleanTodo.Domain.DTOS.Ships;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Enums;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using Moq;

namespace TodoApplicationTests
{
   public class ShipsTests
   {
      private Mock<IShipRepository> _shipRepository;

      private GetAllShipsUseCase _getAllShipsUseCase;

      private GetShipUseCase _getShipUseCase;

      private CreateShipUseCase _createShipUseCase;

      private DeleteShipUseCase _deleteShipUseCase;

      private UpdateShipUseCase _updateShipUseCase;

      private IValidator<CreateShipDto> _createShipValidator;

      private IValidator<UpdateShipDto> _updateShipValidator;

      private Ship _ship1;
      private Ship _ship2;
      private List<Ship> _ships;

      [SetUp]
      public void Setup()
      {
         _createShipValidator = new CreateShipValidation();
         _updateShipValidator = new UpdateShipValidation();
         _shipRepository = new Mock<IShipRepository>();

         _ship1 = new Ship("Going Merry", 50000, "Luffy", 7, ShipStatusEnum.docked);

         _ship2 = new Ship("Thousand Sunny", 750000, "Luffy", 10, ShipStatusEnum.docked);

         _ships = new List<Ship> { _ship1, _ship2 };

         _shipRepository.Setup(repo => repo.GetAll()).ReturnsAsync(_ships);
         _shipRepository.Setup(repo => repo.Delete(_ship1.Id)).ReturnsAsync(true);

         _getAllShipsUseCase = new GetAllShipsUseCase(_shipRepository.Object);
         _getShipUseCase = new GetShipUseCase(_shipRepository.Object);
         _createShipUseCase = new CreateShipUseCase(_shipRepository.Object, _createShipValidator);
         _updateShipUseCase = new UpdateShipUseCase(_shipRepository.Object, _updateShipValidator);
         _deleteShipUseCase = new DeleteShipUseCase(_shipRepository.Object);
      }

      [Test]
      public async Task GetAllTodos_ShouldReturnShipList()
      {
         var result = await _getAllShipsUseCase.Execute();

         Assert.That(result, Is.Not.Null);
         Assert.That(result, Has.Count.EqualTo(2));
      }

      [Test]
      public async Task CreateShip_ShouldReturnCreatedShip()
      {
         CreateShipDto createShipDto = new CreateShipDto("Test navire", 1, "Capitaine Test", 4);
         var result = await _createShipUseCase.Execute(createShipDto);

         Assert.That(result, Is.Not.Null);
         Assert.That(result.Name, Is.EqualTo(createShipDto.Name));
         Assert.That(result.GoldCargo, Is.EqualTo(createShipDto.GoldCargo));
         Assert.That(result.Captain, Is.EqualTo(createShipDto.Captain));
         Assert.That(result.CrewSize, Is.EqualTo(createShipDto.CrewSize));
      }

      [Test]
      public async Task DeleteShip_ShouldDeleteShip()
      {
         await _deleteShipUseCase.Execute(_ship1.Id);

         _shipRepository.Verify(repo => repo.Delete(_ship1.Id));
      }
   }
}
