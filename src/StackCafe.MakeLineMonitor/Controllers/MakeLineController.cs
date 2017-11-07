using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Nimbus;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        private readonly IMakeLineService _makeLineService;

        public MakeLineController( IMakeLineService makeLineService)
        {
            _makeLineService = makeLineService;
        }

        public ActionResult Index()
        {
            var model = new MakeLineViewModel(_makeLineService.GetLineItems());
            return View(model);
        }

        public JsonResult GetOrderItems()
        {
            return Json(_makeLineService.GetLineItems());
        }
    }
}
