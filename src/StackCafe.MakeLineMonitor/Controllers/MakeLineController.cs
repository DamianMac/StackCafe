using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        public MakeLineController(IMakeLineService makeLineService)
        {
            _makeLineService = makeLineService;
        }

        private readonly IMakeLineService _makeLineService;

        public ActionResult Index()
        {
            var coffees = this._makeLineService.GetAll();
            var model = new MakeLineViewModel(coffees);
            return View(model);
        }
    }
}