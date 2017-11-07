using System;
using System.Linq;
using Serilog;
using StackCafe.Waiter.Ef;

namespace StackCafe.Waiter.Services
{
    public class OrderDeliveryService : IOrderDeliveryService
    {
        private readonly ILogger _logger;

        public OrderDeliveryService(ILogger logger)
        {
            _logger = logger;
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

            CheckWhetherWeShouldDeliver(orderId);
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

            CheckWhetherWeShouldDeliver(orderId);
        }

        private void CheckWhetherWeShouldDeliver(Guid orderId)
        {
            using (var dbcontext = new WaiterContext())
            {
                var order = dbcontext.Orders.AsNoTracking().Where(x => x.Id == orderId).FirstOrDefault();

                if (order != null)
                {
                    if (!order.Made)
                    {
                        _logger.Information("{OrderId} isn't ready yet. We can't give it to the customer.", orderId);
                        return;
                    }

                    if (!order.Paid)
                    {
                        _logger.Information("{OrderId} hasn't been paid for yet. We can't give it to the customer.", orderId);
                        return;
                    }

                    DeliverOrderToCustomer(orderId);
                }
                else
                {
                    _logger.Information("{OrderId} can't be fount.", orderId);
                }
            }
        }

        private void DeliverOrderToCustomer(Guid orderId)
        {
            _logger.Information("Delivering {OrderId} to the customer.", orderId);
        }
    }
}