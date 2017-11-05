using StackCafe.Catalog.MessageContracts;

namespace StackCafe.Catalog.Messaging
{
    public interface IHandleCommand<TBusCommand> where TBusCommand : IBusCommand
    {
        void Handle(TBusCommand busCommand);
    }
}
