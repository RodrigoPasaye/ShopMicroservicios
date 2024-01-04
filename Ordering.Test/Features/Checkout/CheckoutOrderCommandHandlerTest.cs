using AutoMapper;
using Moq;
using Ordering.Application.Contracts;
using Ordering.Application.Features.Commands.Checkout;
using Ordering.Domain.Entities;

namespace Ordering.Test.Features.Checkout {
  public class CheckoutOrderCommandHandlerTest {
    //creamos Mocks de los objetos repository y mapper
    private readonly Mock<IGenericRepository<Order>> repositoryMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly CheckoutOrderCommandHandler handler;
    public CheckoutOrderCommandHandlerTest() {
      repositoryMock = new Mock<IGenericRepository<Order>>();
      mapperMock = new Mock<IMapper>();
      //hacemos la instanci del handler enviandole los objetos de la inyeccion de dependencia
      handler = new CheckoutOrderCommandHandler(repositoryMock.Object, mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddNewOrder() {
      //Arrange
      var checkoutOrderCommand = new CheckoutOrderCommand() {
        UserName = "Test",
        Address = "Hola@hola.com",
        FirstName = "Test",
        LastName = "Test",
        PaymentMethod = 1,
        TotalPrice = 10
      };

      var orderEntity = new Order {
        Id = 12,
      };

      mapperMock.Setup(x => x.Map<Order>(checkoutOrderCommand)).Returns(orderEntity);
      repositoryMock.Setup(x => x.AddAsync(orderEntity)).ReturnsAsync(orderEntity);

      //Act
      var result = await handler.Handle(checkoutOrderCommand, CancellationToken.None);

      //Assert
      repositoryMock.Verify(r => r.AddAsync(orderEntity), Times.Once);
      mapperMock.Verify(m => m.Map<Order>(checkoutOrderCommand), Times.Once);
      Assert.Equal(result, orderEntity.Id);
    }
  }
}
