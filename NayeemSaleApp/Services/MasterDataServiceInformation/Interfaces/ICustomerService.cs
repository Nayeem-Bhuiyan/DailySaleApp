using NayeemSaleApp.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Services.MasterDataServiceInformation.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int? Id);
        Task<bool> Insert(Customer model);
        Task<bool> Update(Customer model);
        Task<bool> DeleteById(int? Id);
    }
}
