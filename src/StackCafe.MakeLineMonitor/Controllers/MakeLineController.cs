using System.Linq;
using System.Web.Mvc;
using Serilog;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
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

        public ActionResult Index(string menuItemType)
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetItems(string menuItemType)
        {
            var model = new MakeLineViewModel(_makeLine.Get().SelectMany(l => l).Where(i => i.ItemType == menuItemType).Select(i => i.ItemName).ToArray());
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
