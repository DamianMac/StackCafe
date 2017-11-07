using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        public ActionResult Index()
        {
            var model = new MakeLineViewModel("Doppio", "Flat white", "Long black", "Doppio", "Doppio");
            return View(model);
        }
    }
}