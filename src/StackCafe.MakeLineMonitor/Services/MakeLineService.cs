using System;
using System.Linq;
using StackCafe.MakeLineMonitor.Ef;

namespace StackCafe.MakeLineMonitor.Services
{
    public class MakeLineService : IMakeLineService
    {
        public void Add(Guid orderId, string coffeeType)
        {
            using (var dbcontext = new MakeLineMonitorContext())
            {
                dbcontext.Orders.Add(new Models.Order()
                {
                    Id = orderId,
                    Coffee = coffeeType
                });
                dbcontext.SaveChanges();
            }

            Serilog.Log.Information("Adding Order {orderId} for {new}", orderId, coffeeType);
        }

        public void Remove(Guid orderId)
        {
            using (var dbcontext = new MakeLineMonitorContext())
            {
                var order = dbcontext.Orders.SingleOrDefault(x => x.Id == orderId);

                if (order != null)
                {
                    dbcontext.Orders.Remove(order);
                    dbcontext.SaveChanges();
                    Serilog.Log.Information("Removing Order {orderId}", orderId);
                }
                else
                {
                    Serilog.Log.Warning("Could not find order id {orderId} to remove it", orderId);
                }
            }
        }

        public string[] GetAll()
        {
            using (var dbcontext = new MakeLineMonitorContext())
            {
                return dbcontext.Orders.Select(x => x.Coffee).ToArray();
            }
        }

        public bool IsEmpty()
        {
            using (var dbcontext = new MakeLineMonitorContext())
            {
                return dbcontext.Orders.Select(x => x.Id).Any();
            }
        }
    }
}