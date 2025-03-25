using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        #region Without Specification

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int Id);

        #endregion


        #region With Sepcification

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISepecifications<T> Spec);

        Task<T> GetByIdWithSpecAsync(ISepecifications<T> Spec);
        #endregion

        Task<int> GetCountWithSpecAsync(ISepecifications<T> Spec);


        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);


    }
}
