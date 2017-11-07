using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCafe.Waiter.Services
{
    public class OrderLockService : IOrderLockService
    {
        private readonly System.Threading.SemaphoreSlim semaphore = new System.Threading.SemaphoreSlim(1);

        public void Release()
        {
            this.semaphore.Release();
        }

        public async Task Wait()
        {
           await this.semaphore.WaitAsync();
        }
    }
}
