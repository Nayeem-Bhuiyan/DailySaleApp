using Microsoft.AspNetCore.Mvc;
using NayeemSaleApp.Areas.Sale.Models;
using NayeemSaleApp.Services.MasterDataServiceInformation.Interfaces;
using NayeemSaleApp.Services.PaymentRecordServiceInformation.Interfaces;
using NayeemSaleApp.Services.SaleRecordServiceInformation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.Sale.Controllers
{
    [Area("Sale")]
        public class SaleRecordInfoController : Controller
        {

        private readonly IProductService _ProductService;
        private readonly ICustomerService _CustomerService;
        private readonly ISaleRecordService _SaleRecordService;
        private readonly IPaymentRecordService _PaymentRecordServic;

        public SaleRecordInfoController(IProductService ProductService, ICustomerService CustomerService, ISaleRecordService SaleRecordService, IPaymentRecordService PaymentRecordServic)
        {
            _ProductService = ProductService ?? throw new ArgumentNullException(nameof(ProductService));
            _CustomerService = CustomerService ?? throw new ArgumentNullException(nameof(CustomerService));
            _SaleRecordService = SaleRecordService ?? throw new ArgumentNullException(nameof(SaleRecordService));
            _PaymentRecordServic = PaymentRecordServic ?? throw new ArgumentNullException(nameof(PaymentRecordServic));
        }


        [HttpGet]
            public async Task<ActionResult<IEnumerable<SaleRecordViewModel>>> Index()
            {
               SaleRecordViewModel vmModel = new SaleRecordViewModel()
                {
                    products = await _ProductService.GetAll(),
                    customers = await _CustomerService.GetAll(),

                };
                return View(vmModel);
            }



            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<ActionResult> Index([FromForm] SaleRecordViewModel model)
            //{

            //    if (model.ProductId > 0)
            //    {

            //        //Product updateObj = new Product()
            //        //{
            //        //    Id = model.ProductId,
            //        //    productName = model.productName,
            //        //    productCode = model.productCode
            //        //};
            //        //await _ProductService.Update(updateObj);
            //    }
            //    else
            //    {
            //        //Product insertObj = new Product()
            //        //{

            //        //    productName = model.productName,
            //        //    productCode = model.productCode
            //        //};
            //        //await _ProductService.Insert(insertObj);

            //    }
            //    return Redirect("/MasterData/ProductInfo/Index");

            //}

            //[HttpPost]
            //public async Task<ActionResult> Delete(int? Id)
            //{
            //    return Json(await _ProductService.DeleteById(Id));
            //}
        
    }
}
