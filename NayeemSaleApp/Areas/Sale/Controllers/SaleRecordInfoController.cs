using Microsoft.AspNetCore.Mvc;
using NayeemSaleApp.Areas.Sale.Models;
using NayeemSaleApp.Data.Entity.PaymentRecordEntity;
using NayeemSaleApp.Data.Entity.SaleRecordEntity;
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

        [HttpPost]
        public async Task<ActionResult> SaveSaleRecord(SaleRecordModel model)
        {

            int? saveCount=0;
            bool response = false;
            foreach (var data in model.productList)
            {

                SaleRecord SaleRecordObj = new SaleRecord
                {
                    Id=model.SaleRecordId,
                    ProductId = data.ProductId,
                    CustomerId = model.CustomerId,
                    rate = data.rate,
                    quantity = data.quantity,
                    billDate = model.billDate,
                    boucherNumber = model.boucherNumber,
                    createdAt = DateTime.Now
                };
                if (model.SaleRecordId > 0)
                {
                    response = await _SaleRecordService.Update(SaleRecordObj);
                    if (response)
                    {
                        saveCount += 1;
                    }
                }
                else
                {
                    response = await _SaleRecordService.Insert(SaleRecordObj);
                    if (response)
                    {
                        saveCount += 1;
                    }

                }

            }

            return Json(saveCount);

        }

        [HttpPost]
        public async Task<ActionResult> SaveSale([FromBody] SaleRecordViewModel model)
        {
            

                SaleRecord SaleRecordObj = new SaleRecord
                {
                    ProductId = model.ProductId,
                    CustomerId = model.CustomerId,
                    rate = model.rate,
                    quantity = model.quantity,
                    billDate = model.billDate,
                    boucherNumber = model.boucherNumber,
                    createdAt = DateTime.Now
                };
                if (model.SaleRecordId > 0)
                {
                     await _SaleRecordService.Update(SaleRecordObj);
                }
                else
                {
                     await _SaleRecordService.Insert(SaleRecordObj);

                }
            
            return Json(model);

        }


        [HttpPost]
        public async Task<ActionResult> SavePayment([FromBody] SaleRecordViewModel model)
        {
            bool response = false;
            
            if (model.receiveTotal != null && model.grossAmount != null && model.boucherNumber!=null)
            {
                PaymentRecord PaymentObj = new PaymentRecord
                {
                    CustomerId = model.CustomerId,
                    grossAmount = model.grossAmount,
                    discountAmount = model.discountAmount,
                    vatAmount = model.vatAmount,
                    receiveTotal = model.receiveTotal,
                    payType = model.payType,
                    remarks = model.remarks,
                    createdAt = DateTime.Now
                };

                if (model.PaymentRecordId > 0)
                {
                    response = await _PaymentRecordServic.Update(PaymentObj);
                }
                else
                {
                    response = await _PaymentRecordServic.Insert(PaymentObj);
                }
            }
            return Json(response);

        }
    }
}
