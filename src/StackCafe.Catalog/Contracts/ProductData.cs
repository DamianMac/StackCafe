using System;

namespace StackCafe.Catalog.Contracts
{
    public struct ProductData
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Code { get; }

        public ProductData(Guid id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}
