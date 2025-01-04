using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext;

        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }





        public async Task<IEnumerable<T>> GetAllAsync()
        {

            return await _dbcontext.Set<T>().ToListAsync(); 

        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbcontext.Set<T>().FindAsync(Id);
        }
    }
}
