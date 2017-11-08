using System.Linq;
using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        private readonly IAccountingService _accountingService;
        private readonly IMakeLineService _makeLineService;

        public MakeLineController(IAccountingService accountingService, IMakeLineService makeLineService)
        {
            _accountingService = accountingService;
            _makeLineService = makeLineService;
        }
        public ActionResult Index()
        {
            var model = new MakeLineViewModel(_makeLineService.GetItems().ToArray());
            model.TotalAudSales = _accountingService.Aud.Amount;
            model.TotalBtcSales = _accountingService.Btc.Amount;
            return View(model);
        }
    }
}