using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.Sale.Controllers
{
    [Area("Sale")]
    public class SaleRecordInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
