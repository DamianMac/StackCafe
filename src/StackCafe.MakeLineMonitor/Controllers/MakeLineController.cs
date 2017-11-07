using System.Linq;
using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        private readonly IMakeLineService _makeLineService;

        public MakeLineController(IMakeLineService makeLineService)
        {
            _makeLineService = makeLineService;
        }

        public ActionResult Index()
        {
            return View(new MakeLineViewModel(_makeLineService.GetOrders().Select(order => new OrderViewModel() { CoffeeType = order.CoffeeType, Colour = order.Colour })));
        }
    }
}