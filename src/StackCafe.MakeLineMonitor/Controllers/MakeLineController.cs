using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        public MakeLineController(IAccountingService accountingService)
        {
            _accountingService = accountingService;
        }
        public ActionResult Index()
        {
            var model = new MakeLineViewModel("Doppio", "Flat white", "Long black", "Doppio", "Doppio");
            model.TotalAudSales = _accountingService.Aud.Amount;
            model.TotalBtcSales = _accountingService.Btc.Amount;
            return View(model);
        }
        private IAccountingService _accountingService;
    }
}