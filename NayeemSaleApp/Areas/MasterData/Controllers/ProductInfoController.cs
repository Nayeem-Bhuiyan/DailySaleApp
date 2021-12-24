using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.MasterData.Controllers
{
    public class ProductInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
