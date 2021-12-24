using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Data.Entity.PaymentRecordEntity
{
    public class PaymentRecord
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float? grossAmount { get; set; }
        public float? discountAmount { get; set; }
        public float? vatAmount { get; set; }
        public float? receiveTotal { get; set; }
        public int? payType { get; set; }
        [StringLength(300)]
        public string remarks { get; set; }

        //created at payDate

    }
}
