using Sha_Task.Base;
using Sha_Task.Models;

namespace Sha_Task.Services.Invoice
{
  
        public interface IInvoiceservices : IEntityBase<InvoiceDetail>
    {
        Task<IEnumerable<InvoiceDetail>> GetByItem();
    }
}
