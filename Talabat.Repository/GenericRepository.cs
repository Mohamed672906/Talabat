using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
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

       #region Wtihout Specififcations

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
                return (IEnumerable<T>)await _dbcontext.products.Include(P => P.ProductBrand).Include(P => P.ProductType).ToListAsync();
            else
                return await _dbcontext.Set<T>().ToListAsync();

        }


        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbcontext.Set<T>().FindAsync(Id);
            // return await _dbcontext.Set<T>().Where(P => P.Id == Id).Include(P => P.ProdctBrand).Include();
        }


        #endregion




        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISepecifications<T> Spec)
        {
          //  return await SpesifictionEvalutor<T>.GetQuery(_dbcontext.Set<T>(), Spec).ToListAsync();
          
            return await ApplySpecifition(Spec).ToListAsync();


        }



        public async Task<T> GetByIdWithSpecAsync(ISepecifications<T> Spec)
        {
           // return await SpesifictionEvalutor<T>.GetQuery(_dbcontext.Set<T>(), Spec).FirstOrDefaultAsync();
          return await ApplySpecifition(Spec).FirstOrDefaultAsync();

        }


        private IQueryable<T> ApplySpecifition(ISepecifications<T> Spec)
        {
                return SpesifictionEvalutor<T>.GetQuery(_dbcontext.Set<T>(), Spec);

        }


    }
}
