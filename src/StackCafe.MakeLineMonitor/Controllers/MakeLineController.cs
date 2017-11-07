using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        private readonly IMakeLineService _service;

        public MakeLineController(IMakeLineService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var model = new MakeLineViewModel(_service.Get());
            return View(model);
        }
    }
}