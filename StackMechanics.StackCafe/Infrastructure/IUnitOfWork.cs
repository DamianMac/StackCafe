namespace StackMechanics.StackCafe.Infrastructure
{
    public interface IUnitOfWork
    {
        void Complete();
        void Abort();
    }
}