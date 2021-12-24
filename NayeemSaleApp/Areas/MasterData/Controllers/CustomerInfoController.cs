using Microsoft.AspNetCore.Mvc;
using NayeemSaleApp.Areas.MasterData.Models;
using NayeemSaleApp.Data.Entity.MasterDataEntity;
using NayeemSaleApp.Services.MasterDataServiceInformation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.MasterData.Controllers
{
    [Area("MasterData")]
    public class CustomerInfoController : Controller
    {

        private readonly ICustomerService _CustomerService;

        public CustomerInfoController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService ?? throw new ArgumentNullException(nameof(CustomerService));
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            CustomerViewModel vmModel = new CustomerViewModel()
            {
                customers = await _CustomerService.GetAll()
            };
            return View(vmModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([FromForm] CustomerViewModel model)
        {

            if (model.CustomerId > 0)
            {

                Customer updateObj = new Customer()
                {
                    Id = model.CustomerId,
                    customerName = model.customerName,
                    contactNumber = model.contactNumber
                };
                await _CustomerService.Update(updateObj);
            }
            else
            {
                Customer insertObj = new Customer()
                {

                    customerName = model.customerName,
                    contactNumber = model.contactNumber
                };
                await _CustomerService.Insert(insertObj);

            }
            return Redirect("/MasterData/CustomerInfo/Index");

        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? Id)
        {
            return Json(await _CustomerService.DeleteById(Id));
        }
    }
}
