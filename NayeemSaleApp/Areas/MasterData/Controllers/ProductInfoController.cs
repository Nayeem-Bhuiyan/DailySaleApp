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
    public class ProductInfoController : Controller
    {
        private readonly IProductService _ProductService;

        public ProductInfoController(IProductService ProductService)
        {
            _ProductService = ProductService ?? throw new ArgumentNullException(nameof(ProductService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            ProductViewModel vmModel = new ProductViewModel()
            {
                products = await _ProductService.GetAll()
            };
            return View(vmModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([FromForm] ProductViewModel model)
        {

            if (model.ProductId > 0)
            {

                Product updateObj = new Product()
                {
                    Id = model.ProductId,
                    productName = model.productName,
                    productCode = model.productCode
                };
                await _ProductService.Update(updateObj);
            }
            else
            {
                Product insertObj = new Product()
                {

                    productName = model.productName,
                    productCode = model.productCode
                };
                await _ProductService.Insert(insertObj);

            }
            return Redirect("/MasterData/ProductInfo/Index");

        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? Id)
        {
            return Json(await _ProductService.DeleteById(Id));
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> AllProduct()
        {
            return Json(await _ProductService.GetAll());
        }

    }
}
