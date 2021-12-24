﻿using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.Sale.Models
{
    public class SaleRecordViewModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float? rate { get; set; }
        public int? quantity { get; set; }
        public DateTime? billDate { get; set; }
        public string boucherNumber { get; set; }
        public float? grossAmount { get; set; }
        public float? discountAmount { get; set; }
        public float? vatAmount { get; set; }
        public float? receiveTotal { get; set; }
        public int? payType { get; set; }
        public string remarks { get; set; }
    }
}
