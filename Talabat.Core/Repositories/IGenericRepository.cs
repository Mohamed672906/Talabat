using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        #region Without Specification

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int Id);

        #endregion


        #region With Sepcification

        Task<IEnumerable<T>> GetAllWithSpecAsync(ISepecifications<T> Spec);

        Task<T> GetByIdWithSpecAsync(ISepecifications<T> Spec); 
        #endregion


    }
}
