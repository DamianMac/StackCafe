using System.Threading.Tasks;

namespace StackCafe.Waiter.Services
{
    public interface IOrderLockService
    {
        Task Wait();

        void Release();
    }
}