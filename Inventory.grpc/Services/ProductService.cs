using Grpc.Core;
using Inventory.grpc.Protos;

namespace Inventory.grpc.Services
{
  public class ProductService : ExistenceService.ExistenceServiceBase
  {
    public override Task<ProductExistenceReply> checkExistence(ProductRequest request, ServerCallContext context)
    {
      //logica va aqui

      return Task.FromResult(new ProductExistenceReply() { ProductQty = 99 });
    }
  }
}
