using CustomCRM.Application.Services.Create;
using CustomCRM.Application.Utilities.DateTimes;
using CustomCRM.Domain.Commons.Errors;
using CustomCRM.Domain.Primitives;
using CustomCRM.Domain.Services;

namespace CustomCRM.Tests.Services.CreateServiceHandler
{
    public class CreateServiceCommandHandlerTests
    {
        private readonly CreateServiceCommandHandler _handler;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IServiceRepository> _mockServiceRepository;
        private readonly Mock<IDateTimeProvider> _mockTimeProvider;

        public CreateServiceCommandHandlerTests() 
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockServiceRepository = new Mock<IServiceRepository>();
            _mockTimeProvider = new Mock<IDateTimeProvider>();
            _handler = new CreateServiceCommandHandler(_mockServiceRepository.Object, _mockUnitOfWork.Object, _mockTimeProvider.Object);
        }

        [Fact]
        public async Task CreateServiceCommandHandler_WhenServiceTypeHasNullFormat_ShouldReturnValidationError()
        {
            //Arrange
            CreateServiceCommand createServiceCommand = new CreateServiceCommand(
                null,
                Domain.Commons.Enums.Difficult.Heroic,
                13,
                Domain.Commons.Enums.Services.Currency.USD,
                4,
                "asd"
                );

            //Act
            var result = await _handler.Handle(createServiceCommand, default);

            //Assert
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Description.Should().Be(ServiceErrors.ServiceTypeIsNotValid.Description);
        }
    }
}
