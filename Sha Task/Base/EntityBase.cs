
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using Sha_Task.Models;
using System.Security.Principal;

namespace Sha_Task.Base
{
    public class EntityBase<T> : IEntityBase<T> where T : class, IBase,new()
    {
        private readonly ShaTaskContext _context;
        public EntityBase(ShaTaskContext shaTaskContext)
        {
            _context = shaTaskContext;
        }
        public async Task Add(T entity)
        {
          await  _context.Set<T>().AddAsync(entity);
          await _context.SaveChangesAsync();
           
        }

        public async Task Delete(int id)
        {
            var entity= await _context.Set<T>().FirstOrDefaultAsync(ent=>ent.Id==id);
             var deletedentity= _context.Entry<T>(entity);
            deletedentity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetALL()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(ent => ent.Id == id);
            
        }

        public async Task Update(T entity)
        {
                var idValue= entity.Id;
                var oldEntity = await _context.Set<T>().FirstOrDefaultAsync(ent => ent.Id == idValue);
  
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);

           
            _context.Entry(oldEntity).State = EntityState.Modified;

            
           await _context.SaveChangesAsync();
        }
    }
}
