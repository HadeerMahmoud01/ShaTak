using Microsoft.EntityFrameworkCore;
using Sha_Task.Base;
using Sha_Task.Models;
using System.Runtime.CompilerServices;


namespace Sha_Task.Services.CashierServices
{
    public class CashierServices: EntityBase<Cashier>, ICashierServices
    {
        private readonly ShaTaskContext _context;
        public CashierServices(ShaTaskContext shaTaskContext):base(shaTaskContext) 
        {
            _context= shaTaskContext;
        }
       
        public  async Task<IEnumerable<Cashier>> GetAll()
        {
            var result = await _context.Cashiers.Include(c => c.Branch).Where(i=>i.CashierName!="").ToListAsync();

            return result;
        }
        public new async Task<IEnumerable<Cashier>> GetALL()
        {
            return await GetAll();
        }
        public async Task<Cashier> GetById(int id)
        {
            var cashier = await _context.Cashiers.Include(b => b.Branch).FirstOrDefaultAsync();
            
            return cashier;
        }
        public async Task Delete(int id)
        {
           var result= await _context.InvoiceHeaders.FirstOrDefaultAsync(i=>i.CashierId==id);
            if (result != null)
            {
                result.CashierId = null;
                var entity = await _context.Set<Cashier>().FirstOrDefaultAsync(ent => ent.Id == id);
                _context.Cashiers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        
    }
   
}
