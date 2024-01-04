﻿using AutoMapper;
using Ordering.Application.Features.Commands.Checkout;
using Ordering.Application.Features.Queries.GetOrders;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
      CreateMap<Order ,GetOrdersViewModel>().ReverseMap();
    }
  }
}
