using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications
{
    public class BaseSepecification<T> : ISepecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnable { get; set; }


        //Get All 
        public BaseSepecification()
        {
            // Includes = new List<Expression<Func<T, object>>>();
        }

        //Get id 

        public BaseSepecification(Expression<Func<T, bool>> criteriaexpreission)
        {
            Criteria = criteriaexpreission;
            // Includes = new List<Expression<Func<T, object>>>();
        }


        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> OrderByDescExpression)
        {

            OrderByDescending = OrderByDescExpression;

        }


        public void ApplyPagination (int skip , int take )
        {
            IsPaginationEnable = true;

            Skip = skip;
            Take = take; 

        }




    }
}
