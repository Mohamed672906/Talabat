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
        public Expression<Func<T, bool>> Criteria { get; set ; }

        public List<Expression<Func<T, object>>> Includes { get; set ; } = new List<Expression<Func<T, object>>>();


        //Get All 
        public BaseSepecification()
        {
           // Includes = new List<Expression<Func<T, object>>>();
        }

        //Get id 

        public BaseSepecification(Expression<Func<T, bool>> criteriaexpreission)
        {
            // Includes = new List<Expression<Func<T, object>>>();
        }



    }
}
