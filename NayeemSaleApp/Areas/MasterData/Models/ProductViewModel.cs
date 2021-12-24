using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.MasterData.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public Product product { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
