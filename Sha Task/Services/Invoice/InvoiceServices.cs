using Microsoft.EntityFrameworkCore;
using Sha_Task.Base;
using Sha_Task.Models;

namespace Sha_Task.Services.Invoice
{
    public class InvoiceServices:EntityBase<InvoiceDetail> , IInvoiceservices
    {
        private readonly ShaTaskContext _context;
        public InvoiceServices(ShaTaskContext shaTaskContext):base(shaTaskContext) 
        {
            _context = shaTaskContext;  
        }

        public async Task<IEnumerable<InvoiceDetail>> GetByItem()
        {
            var result = await _context.InvoiceDetails
            .Include(i => i.InvoiceHeader)
            .Where(i => i.ItemCount > 1)
            .ToListAsync();

            return result;

      

        }
        public async Task<InvoiceDetail> GetById(int id)
        {
            var result= await _context.InvoiceDetails.Include(i=>i.InvoiceHeader).ThenInclude(x=>x.Cashier).ThenInclude(x=>x.Branch).ThenInclude(b=>b.City).FirstOrDefaultAsync();
            return result;
        }
        
    }
}
