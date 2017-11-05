using StackCafe.Catalog.Contracts;
using StackCafe.Catalog.Data;
using StackCafe.Catalog.Messages;
using StackCafe.Catalog.Messaging;

namespace StackCafe.Catalog.Handlers
{
    public class LookupProductRequestHandler : IHandleRequest<LookupProductRequest, LookupProductResponse>
    {
        readonly IProductRepository _products;

        public LookupProductRequestHandler(IProductRepository products)
        {
            _products = products;
        }

        public LookupProductResponse Handle(LookupProductRequest command)
        {
            if (_products.TryLookup(command.Code, out var product))
            {
                return new LookupProductResponse(new ProductData(product.Id, product.Name, product.Code));
            }

            return new LookupProductResponse(null);
        }
    }
}
