using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Areas.Sale.Models
{
    public class SaleRecordViewModel
    {
       
        
           //SaleCord
        public int SaleRecordId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float? rate { get; set; }
        public int? quantity { get; set; }
        public DateTime? billDate { get; set; }
        public string boucherNumber { get; set; }
            //PayRecord
        public int PaymentRecordId { get; set; }
        public float? grossAmount { get; set; }
        public float? discountAmount { get; set; }
        public float? vatAmount { get; set; }
        public float? receiveTotal { get; set; }
        public int? payType { get; set; }
        public string remarks { get; set; }
          //Other
        public int? totalItemCount { get; set; }
        public bool paymentStep { get; set; }

        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Customer> customers { get; set; }

        public List<ProductList> productList { get; set; }
    }


    public class SaleRecordModel
    {
        public SaleRecordModel()
        {
            productList = new List<ProductList>();
        }

        public int? quantity { get; set; }
        public DateTime? billDate { get; set; }
        public int CustomerId { get; set; }
        public string boucherNumber { get; set; }
        public int SaleRecordId { get; set; }
        public List<ProductList> productList { get; set; }
        public Payment payment { get; set; }

    }
    public class ProductList
    {
        //SaleCord
        public int ProductId { get; set; }
        public float? rate { get; set; }
        public int? quantity { get; set; }
    }

    public class Payment
    {
        public int PaymentRecordId { get; set; }
        public float? grossAmount { get; set; }
        public float? discountAmount { get; set; }
        public float? vatAmount { get; set; }
        public float? receiveTotal { get; set; }
        public int? payType { get; set; }
        public string remarks { get; set; }
    }
}
