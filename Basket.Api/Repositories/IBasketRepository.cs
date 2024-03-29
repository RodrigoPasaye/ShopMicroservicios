﻿using Basket.Api.Entities;

namespace Basket.Api.Repositories
{
  public interface IBasketRepository
  {
    Task DeleteBasket(string userName);
    Task<ShoppingCart?> GetBasket(string userName);
    Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
  }
}
