using Microsoft.AspNetCore.Mvc;
using NayeemSaleApp.Areas.MasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.MasterData.Controllers
{
    [Area("MasterData")]
    public class CustomerInfoController : Controller
    {
        public IActionResult Index()
        {
            CustomerViewModel vmData = new CustomerViewModel
            {

            };
            
            
            return View(vmData);
        }
    }
}
