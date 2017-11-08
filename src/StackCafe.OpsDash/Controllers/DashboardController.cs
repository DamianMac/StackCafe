using System.Web.Mvc;
using Nimbus;
using System.Collections;

namespace StackCafe.OpsDash.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public DashboardController(IBus bus)
        {
            _bus = bus;
        }

        public ActionResult Index()
        {
            ViewBag.Count = _bus.DeadLetterOffice.Count().ToString();
            _logger.Info("Deadletter count: {Count}", ViewBag.Count);
            return View(ViewBag);
        }
    }
}