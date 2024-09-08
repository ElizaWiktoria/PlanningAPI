using AutoMapper;
using Azure.Core;
using Moq;
using Planning.Application.Features.Plans.Command.CreatePlan;
using Planning.Domain.Dtos.PlanDtos;
using Planning.Domain.Dtos.RoutineDtos;
using Planning.Domain.Exceptions.PlanningService;
using Planning.Domain.Models;
using Planning.Domain.UnitOfWork;
using System.Linq.Expressions;

namespace Test.Commands.Plans
{
    [TestClass]
    public class CreatePlanCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private CreatePlanCommandHandler _handler;

        [TestInitialize]
        public void Initialize()
        {
            _handler = new CreatePlanCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task Handle_CreatePlanWithCorrectRoutineId_ReturnsPlanDto()
        {
            // Arrange
            var minimalRoutine = new MinimalRoutine
            {
                FrequencyInDays = 1,
                Id = 1,
                LastDone = DateOnly.FromDateTime(DateTime.Now),
                Name = "Test",
            };

            var routine = new Routine
            {
                FrequencyInDays = minimalRoutine.FrequencyInDays,
                Id = minimalRoutine.Id,
                LastDone = minimalRoutine.LastDone,
                Name = minimalRoutine.Name,
                Plans = new List<Plan>()
            };

            var createPlanDto = new CreatePlanDto
            {
                Name = "Plan",
                RoutineId = 1,
                Start = DateTime.Now,
            };

            var plan = new Plan
            {
                Name = "Plan",
                Start = DateTime.Now,
                Routine = routine
            };

            var planDto = new PlanDto
            {
                Id = 1,
                Name = "Plan",
                Start = DateTime.Now,
                Routine = minimalRoutine,
            };

            _mapperMock.Setup(m => m.Map<CreatePlanDto, Plan>(createPlanDto)).Returns(plan);

            var routineMock = new Mock<Routine>();
            _unitOfWorkMock.Setup(u => u.RoutineRepository.GetAsync(It.IsAny<Expression<Func<Routine, bool>>>(), default)).ReturnsAsync(routineMock.Object);
            _unitOfWorkMock.Setup(u => u.PlanRepository.AddAsync(plan)).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.PlanRepository.SaveChangesAsync()).ReturnsAsync(true);

            _mapperMock.Setup(m => m.Map<Plan, PlanDto>(plan)).Returns(planDto);

            var command = new CreatePlanCommand { CreatePlanDto = createPlanDto };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(planDto, result);
            _unitOfWorkMock.Verify(u => u.PlanRepository.AddAsync(plan), Times.Once);
            _unitOfWorkMock.Verify(u => u.PlanRepository.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Handle_CreatePlanWithInCorrectRoutineId_ThrowsIllegalArgumentException()
        {
            // Arrange
            var minimalRoutine = new MinimalRoutine
            {
                FrequencyInDays = 1,
                Id = 1,
                LastDone = DateOnly.FromDateTime(DateTime.Now),
                Name = "Test",
            };

            var routine = new Routine
            {
                FrequencyInDays = minimalRoutine.FrequencyInDays,
                Id = minimalRoutine.Id,
                LastDone = minimalRoutine.LastDone,
                Name = minimalRoutine.Name,
                Plans = new List<Plan>()
            };

            var createPlanDto = new CreatePlanDto
            {
                Name = "Plan",
                RoutineId = 1,
                Start = DateTime.Now,
            };

            var plan = new Plan
            {
                Name = "Plan",
                Start = DateTime.Now,
                Routine = routine
            };

            var planDto = new PlanDto
            {
                Id = 1,
                Name = "Plan",
                Start = DateTime.Now,
                Routine = minimalRoutine,
            };

            _mapperMock.Setup(m => m.Map<CreatePlanDto, Plan>(createPlanDto)).Returns(plan);

            var routineMock = new Mock<Routine>();
            _unitOfWorkMock.Setup(u => u.RoutineRepository.GetAsync(It.IsAny<Expression<Func<Routine, bool>>>(), default)).ReturnsAsync(() => null);
            var command = new CreatePlanCommand { CreatePlanDto = createPlanDto };

            // Act
            var ex = await Assert.ThrowsExceptionAsync<IllegalArgumentException>(async () => await _handler.Handle(command, CancellationToken.None));

            // Assert
            Assert.AreEqual("Routine of given id does not exist.", ex.Message);
        }

        [TestMethod]
        public async Task Handle_CreatePlanWithoutRoutineId_ReturnsPlanDto()
        {
            // Arrange
            var createPlanDto = new CreatePlanDto
            {
                Name = "Plan",
                Start = DateTime.Now,
            };

            var plan = new Plan
            {
                Name = "Plan",
                Start = DateTime.Now,
            };

            var planDto = new PlanDto
            {
                Id = 1,
                Name = "Plan",
                Start = DateTime.Now,
            };

            _mapperMock.Setup(m => m.Map<CreatePlanDto, Plan>(createPlanDto)).Returns(plan);

            _unitOfWorkMock.Setup(u => u.PlanRepository.AddAsync(plan)).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.PlanRepository.SaveChangesAsync()).ReturnsAsync(true);

            _mapperMock.Setup(m => m.Map<Plan, PlanDto>(plan)).Returns(planDto);

            var command = new CreatePlanCommand { CreatePlanDto = createPlanDto };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(planDto, result);
            _unitOfWorkMock.Verify(u => u.PlanRepository.AddAsync(plan), Times.Once);
            _unitOfWorkMock.Verify(u => u.PlanRepository.SaveChangesAsync(), Times.Once);
        }
    }
}
