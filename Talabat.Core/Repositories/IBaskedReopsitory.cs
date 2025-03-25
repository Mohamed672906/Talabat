using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Repositories
{
    public interface IBaskedReopsitory
    {
        //Get Basket
        Task<Customerbasket?> GetBasketAsync(string BasketId);

        //UpdateBasket

        Task<Customerbasket?> UpdateBasketAsync(Customerbasket BasketId);


        //Delete Basket 

        Task<bool> DeleteBasketAsync(string Basket);


    }
}
