using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Services.MasterDataServiceInformation.Interfaces
{
   public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int? Id);
        Task<bool> Insert(Product model);
        Task<bool> Update(Product model);
        Task<bool> DeleteById(int? Id);
    }
}
