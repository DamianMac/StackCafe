using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;
using System.Linq;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        readonly IMakeLineService _makeLineService;
        public MakeLineController(IMakeLineService makeLineService )
        {
            this._makeLineService = makeLineService;
        }
        public ActionResult Index()
        {
            var makeLineItems = _makeLineService.GetMakeline().ToArray();
            var model = new MakeLineViewModel(makeLineItems);
            return View(model);
        }
    }
}