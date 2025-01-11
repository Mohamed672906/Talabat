using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications
{
    public interface ISepecifications<T> where T : BaseEntity
    {

        public Expression<Func<T , bool >>  Criteria { get; set; }


        public List<Expression<Func<T , object>>> Includes { get; set; }



        // prop OrderBy [OrderBy (P=>P.Name)]

        public Expression<Func<T , object>> OrderBy { get; set; }

        // prop OrderByDesc [OrderByDesc (P=>P.Name)]

        public Expression<Func<T, object>> OrderByDescending { get; set; }



    }
}
