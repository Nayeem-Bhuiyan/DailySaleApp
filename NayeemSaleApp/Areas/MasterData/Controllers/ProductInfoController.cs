using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.MasterData.Controllers
{
    [Area("MasterData")]
    public class ProductInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
