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
            var model = new MakeLineViewModel(this._makeLineService.CurrentOrders);
            return View(model);
        }
    }
}