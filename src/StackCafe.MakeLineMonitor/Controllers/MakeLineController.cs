using System;
using System.Linq;
using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        private readonly IMakeLineService makeLineService;

        public MakeLineController(IMakeLineService makeLineService)
        {
            this.makeLineService = makeLineService;
        }

        public ActionResult Index()
        {
            var coffees = this.makeLineService.GetOrders().ToArray();
            var model = new MakeLineViewModel(coffees);
            return View(model);
        }
    }
}