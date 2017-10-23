namespace StackMechanics.StackCafe.Infrastructure
{
    public interface IHandleEvent<TEvent> where TEvent : IEvent
    {
        void Handle(TEvent e);
    }
}