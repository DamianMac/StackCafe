using StackCafe.Catalog.Model;

namespace StackCafe.Catalog.Data
{
    public interface IProductRepository
    {
        void Add(Product product);
        bool TryLookup(string code, out Product product);
    }
}
