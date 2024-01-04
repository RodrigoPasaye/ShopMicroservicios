using AutoMapper;
using MediatR;
using Ordering.Application.Contracts;
using Ordering.Application.Features.Queries.GetOrders;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Queries.GetOrdersByUser
{
  public class GetOrdersByUserQueryHandlre : IRequestHandler<GetOrdersByUserQuery, List<GetOrdersViewModel>>
  {
    private readonly IGenericRepository<Order> genericRepository;
    private readonly IMapper mapper;

    public GetOrdersByUserQueryHandlre(IGenericRepository<Order> genericRepository, IMapper mapper)
    {
      this.genericRepository = genericRepository;
      this.mapper = mapper;
    }
    public async Task<List<GetOrdersViewModel>> Handle(GetOrdersByUserQuery request, CancellationToken cancellationToken)
    {
      var orders = await genericRepository.GetAsync(x => x.UserName == request.UserName);

      return mapper.Map<List<GetOrdersViewModel>>(orders);
    }
  }
}
