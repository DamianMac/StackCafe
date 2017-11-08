using System;
using System.Linq;
using System.Threading.Tasks;
using Nimbus;
using Serilog;
using StackCafe.MessageContracts.Commands;
using StackCafe.Waiter.Ef;
using StackCafe.Waiter.Models;

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

        public Order GetOrderFromId(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.AsNoTracking().Where(x => x.Id == orderId).FirstOrDefault();

                if (order == null)
                {
                    _logger.Information("{OrderId} can't be found.", orderId);

                    throw new Exception();
                }

                return order;
            }
        }

        public void MarkAsMade(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.Where(x => x.Id == orderId).FirstOrDefault();

                if (order == null)
                {
                    var newOrder = new Order(orderId);
                    newOrder.MarkAsMade();
                    dbcontext.Orders.Add(newOrder);
                }
                else
                {
                    order.MarkAsMade();
                }

                dbcontext.SaveChanges();
            }

            HandleOrderOutcome(orderId);
        }

        public void MarkAsPaid(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.Where(x => x.Id == orderId).FirstOrDefault();

                if (order == null)
                {
                    var newOrder = new Models.Order(orderId);
                    newOrder.MarkAsPaid();
                    dbcontext.Orders.Add(newOrder);
                }
                else
                {
                    order.MarkAsPaid();
                }

                dbcontext.SaveChanges();
            }

            HandleOrderOutcome(orderId);
        }
        private bool CheckWhetherWeShouldDeliver(Guid orderId)
        {
            try
            {
                var order = this.GetOrderFromId(orderId);

                return order.CanBeDelivered();
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void DeliverOrderToCustomer(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.Where(x => x.Id == orderId).FirstOrDefault();

                if (order != null)
                {
                    order.MarkAsDelivered();
                }

                dbcontext.SaveChanges();
            }
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
    }
}