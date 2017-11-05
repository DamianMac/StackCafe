using StackCafe.Catalog.Contracts;
using StackCafe.Catalog.MessageContracts;

namespace StackCafe.Catalog.Messages
{
    public class AddProductCommand : IBusCommand
    {
        public ProductData Product { get; }

        public AddProductCommand(ProductData product)
        {
            Product = product;
        }
    }
}
