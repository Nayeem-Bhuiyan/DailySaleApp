using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Data.Entity.SaleRecordEntity
{
    [Table("SaleRecord")]
    public class SaleRecord:Base
    {

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public float? rate { get; set; }
        public int? quantity { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime? billDate { get; set; }
        [StringLength(100)]
        public string boucherNumber { get; set; }
    }
}
