using StackCafe.Catalog.Data;
using StackCafe.Catalog.Messages;
using StackCafe.Catalog.Messaging;
using StackCafe.Catalog.Model;

namespace StackCafe.Catalog.Handlers
{
    public class AddProductCommandHandler : IHandleCommand<AddProductCommand>
    {
        readonly IProductRepository _products;

        public AddProductCommandHandler(IProductRepository products)
        {
            _products = products;
        }

        public void Handle(AddProductCommand busCommand)
        {
            _products.Add(new Product
            {
                Id = busCommand.Product.Id,
                Name = busCommand.Product.Name,
                Code = busCommand.Product.Code
            });
        }
    }
}
