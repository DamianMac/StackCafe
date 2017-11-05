using StackCafe.Catalog.MessageContracts;

namespace StackCafe.Catalog.Messages
{
    public class LookupProductRequest : IBusRequest<LookupProductRequest, LookupProductResponse>
    {
        public string Code { get; }

        public LookupProductRequest(string code)
        {
            Code = code;
        }
    }
}
