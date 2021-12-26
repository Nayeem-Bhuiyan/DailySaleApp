using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.Sale.Models
{
    public class CustomerBillSummary
    {
        public int CustomerId { get; set; }
        public string customerName { get; set; }
        public string contactNumber { get; set; }
        public decimal grandTotal { get; set; }
        public decimal totalReceive { get; set; }
        public decimal totalDue { get; set; }
    }
}
