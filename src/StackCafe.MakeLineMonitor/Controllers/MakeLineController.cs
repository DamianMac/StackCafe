using System.Linq;
using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        private IMakeLineService _makeLineService;

        public MakeLineController(IMakeLineService makeLineService)
        {
            _makeLineService = makeLineService;
        }

        public ActionResult Index()
        {
            var model = new MakeLineViewModel(_makeLineService.GetAllItems().Select(orderItem => new OrderItemViewModel() { Name = orderItem.Name, WasRecommended = orderItem.WasRecommended }).ToArray());
            return View(model);
        }
    }
}