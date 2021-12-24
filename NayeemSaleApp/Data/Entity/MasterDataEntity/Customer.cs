using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Data.Entity.MasterDataEntity
{
    public class Customer:Base
    {
        [StringLength(100)]
        public string customerName { get; set; }
        [StringLength(100)]
        public string contactNumber { get; set; }
    }
}
