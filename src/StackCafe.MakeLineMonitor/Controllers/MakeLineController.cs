using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        public ActionResult Index()
        {
            var model = new MakeLineViewModel(_makeLine.Get());
            return View(model);
        }

        [HttpGet]
        public JsonResult GetItems()
        {
            var model = new MakeLineViewModel(_makeLine.Get());
            return Json(model);
        }
    }
}