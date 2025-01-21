using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Service
{
    public interface IPaymentService
    {

        //Function To Create Or Update Payment Intent
        Task<Customerbasket?> CreateOrUpdatePaymentIntent(string BasketId);


    }
}
