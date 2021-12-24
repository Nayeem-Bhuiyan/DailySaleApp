using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Data.Entity.MasterDataEntity
{
    public class Product : Base
    {
        [StringLength(100)]
        public string productName { get; set; }
        [StringLength(100)]
        public string productCode { get; set; }
    }
}
