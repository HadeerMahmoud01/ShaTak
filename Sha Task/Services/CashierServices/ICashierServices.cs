using Microsoft.EntityFrameworkCore;
using Sha_Task.Base;
using Sha_Task.Models;

namespace Sha_Task.Services.CashierServices
{
    public interface ICashierServices : IEntityBase<Cashier>
    {
        public  Task<IEnumerable<Cashier>> GetAll();
        
    }

}
