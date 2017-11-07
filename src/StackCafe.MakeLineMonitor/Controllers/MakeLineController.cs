using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        public MakeLineController(IMakeLineService makeLineService)
        {
            _MakeLineService = makeLineService;
        }

        private IMakeLineService _MakeLineService { get; }

        public ActionResult Index()
        {
            var coffees = this._MakeLineService.GetAll();
            var model = new MakeLineViewModel(coffees);
            return View(model);
        }
    }
}