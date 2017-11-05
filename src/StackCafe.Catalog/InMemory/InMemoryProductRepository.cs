using System;
using System.Collections.Generic;
using System.Linq;
using StackCafe.Catalog.Data;
using StackCafe.Catalog.Model;

namespace StackCafe.Catalog.InMemory
{
    public class InMemoryProductRepository : IProductRepository
    {
        readonly Dictionary<Guid, Product> _products = new Dictionary<Guid, Product>();

        public void Add(Product product)
        {
            if (_products.ContainsKey(product.Id))
                return;

            if (_products.Values.Any(p => p.Code == product.Code))
                throw new ArgumentException($"The product code {product.Code} is not unique.");

            _products.Add(product.Id, product);
        }

        public bool TryLookup(string code, out Product product)
        {
            product = _products.Values.SingleOrDefault(p => p.Code == code);
            return product != null;
        }
    }
}
