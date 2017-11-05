namespace StackCafe.Catalog.Contracts
{
    public class AddProductRequest
    {
        public string Name { get; }
        public string Code { get; }

        public AddProductRequest(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
