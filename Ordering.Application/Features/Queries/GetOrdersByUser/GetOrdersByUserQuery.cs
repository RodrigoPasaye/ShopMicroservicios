using MediatR;
using Ordering.Application.Features.Queries.GetOrders;

namespace Ordering.Application.Features.Queries.GetOrdersByUser
{
  public class GetOrdersByUserQuery : IRequest<List<GetOrdersViewModel>>
  {
    public string UserName { get; set; } = null!;
  }
}
