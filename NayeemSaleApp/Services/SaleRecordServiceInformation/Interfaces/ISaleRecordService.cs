using NayeemSaleApp.Data.Entity.SaleRecordEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Services.SaleRecordServiceInformation.Interfaces
{
  public interface ISaleRecordService
    {
        Task<IEnumerable<SaleRecord>> GetAll();
        Task<SaleRecord> GetById(int? Id);
        Task<bool> Insert(SaleRecord model);
        Task<bool> Update(SaleRecord model);
        Task<bool> DeleteById(int? Id);
    }
}
