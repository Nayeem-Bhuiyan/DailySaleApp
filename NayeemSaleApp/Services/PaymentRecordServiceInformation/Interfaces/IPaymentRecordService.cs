using NayeemSaleApp.Data.Entity.PaymentRecordEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NayeemSaleApp.Services.PaymentRecordServiceInformation.Interfaces
{
    public interface IPaymentRecordService
    {
        Task<IEnumerable<PaymentRecord>> GetAll();
        Task<PaymentRecord> GetById(int? Id);
        Task<bool> Insert(PaymentRecord model);
        Task<bool> Update(PaymentRecord model);
        Task<bool> DeleteById(int? Id);
    }
}
