using StackCafe.Catalog.Contracts;
using StackCafe.Catalog.MessageContracts;

namespace StackCafe.Catalog.Messages
{
    public class LookupProductResponse : IBusResponse
    {
        public ProductData? Product { get; }

        public LookupProductResponse(ProductData? product)
        {
            Product = product;
        }
    }
}
