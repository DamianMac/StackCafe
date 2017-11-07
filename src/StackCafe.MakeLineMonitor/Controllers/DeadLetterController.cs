using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Nimbus;
using StackCafe.MakeLineMonitor.Models;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class DeadLetterController : Controller
    {
        private readonly IBus _bus;

        public DeadLetterController(IBus bus)
        {
            this._bus = bus;
        }

        public async Task<ActionResult> Index()
        {
            var numberOfDeadLetters = await this._bus.DeadLetterOffice.Count();
            if (numberOfDeadLetters < 1)
            {
                return View(new DeadLetterViewModel());
            }

            var nimbusMessage = await this._bus.DeadLetterOffice.Peek();
            return View(new DeadLetterViewModel(numberOfDeadLetters, nimbusMessage));
        }
    }
}