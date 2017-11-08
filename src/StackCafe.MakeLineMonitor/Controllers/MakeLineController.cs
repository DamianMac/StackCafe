using System.Linq;
using System.Web.Mvc;
using Serilog;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Models
{
    public class MakeLineController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMakeLineService _makeLine;

        public MakeLineController(ILogger logger, IMakeLineService makeLine)
        {
            _logger = logger;
            _makeLine = makeLine;
        }

        public ActionResult Index(string view)
        {
            var model = new MakeLineViewModel()
            {
                view = view
            };

            return View(model);
        }

        [HttpGet]
        public JsonResult GetItems(string view)
        {
            var model = new MakeLineItemsViewModel(
                _makeLine.Get()
                .SelectMany(l => l)
                .Where(i => i.Type == view)
                .Select(i => i.Name)
                .ToArray()
            );
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
