using System;
using System.Linq;
using System.Threading.Tasks;
using Nimbus;
using Serilog;
using StackCafe.MessageContracts.Commands;
using StackCafe.Waiter.Ef;

namespace StackCafe.Waiter.Services
{
    public class OrderDeliveryService : IOrderDeliveryService
    {
        private readonly Serilog.ILogger _logger;
        private readonly IBus bus;

        public OrderDeliveryService(Serilog.ILogger logger, IBus bus)
        {
            _logger = logger;
            this.bus = bus;
        }

        public void MarkAsPaid(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.Where(x => x.Id == orderId).FirstOrDefault();

                if (order == null)
                {
                    dbcontext.Orders.Add(new Models.Order()
                    {
                        Id = orderId,
                        Paid = true
                    });
                }
                else
                {
                    order.Paid = true;
                }

                dbcontext.SaveChanges();
            }

            HandleOrderOutcome(orderId);
        }

        public void MarkAsMade(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.Where(x => x.Id == orderId).FirstOrDefault();

                if (order == null)
                {
                    dbcontext.Orders.Add(new Models.Order()
                    {
                        Id = orderId,
                        Made = true
                    });
                }
                else
                {
                    order.Made = true;
                }

                dbcontext.SaveChanges();
            }

            HandleOrderOutcome(orderId);
        }

        private void HandleOrderOutcome(Guid orderId)
        {
            if (CheckWhetherWeShouldDeliver(orderId))
            {
                DeliverOrderToCustomer(orderId);
            }
            else
            {
                ScheduleFutureCheckPendingOrder(orderId).GetAwaiter().GetResult();
            }
        }

        private async Task ScheduleFutureCheckPendingOrder(Guid orderId)
        {
            var command = new CheckPendingOrderCommand(orderId);
            await this.bus.SendAfter(command, new TimeSpan(hours: 0, minutes: 5, seconds: 0));

            _logger.Information("{OrderId} isn't ready yet. Sending a message in to the future.", orderId);
        }

        private bool CheckWhetherWeShouldDeliver(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.AsNoTracking().Where(x => x.Id == orderId).FirstOrDefault();

                if (order == null)
                {
                    _logger.Information("{OrderId} can't be fount.", orderId);

                    return false;
                }

                return order.CanBeDelivered();
            }
        }

        private void DeliverOrderToCustomer(Guid orderId)
        {

            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.AsNoTracking().Where(x => x.Id == orderId).FirstOrDefault();
                order.MarkAsDelivered();
            }
        }
    }
}