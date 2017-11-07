using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using StackCafe.MakeLineMonitor.Models;
using StackCafe.MakeLineMonitor.Services;

namespace StackCafe.MakeLineMonitor.Controllers
{
    public class MakeLineController : Controller
    {
        private readonly IMakeLineService _mls;

        public MakeLineController(IMakeLineService mls)
        {
            _mls = mls;
        }

        public ActionResult Index()
        {
           // StackCafe.MakeLineMonitor.Services.MakeLineService;
         
    

               

           var model = new MakeLineViewModel(_mls.Items);

 
            return View(model);
        }
    }
}