using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.MasterData.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string customerName { get; set; }
        public string contactNumber { get; set; }
        public Customer customer { get; set; }
        public IEnumerable<Customer> customers { get; set; }
    }
}
