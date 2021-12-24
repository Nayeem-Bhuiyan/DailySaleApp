using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NayeemSaleApp.Data.Entity;
using NayeemSaleApp.Data.Entity.MasterDataEntity;
using NayeemSaleApp.Data.Entity.PaymentRecordEntity;
using NayeemSaleApp.Data.Entity.SaleRecordEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleRecord> SaleRecords { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
    }
}
