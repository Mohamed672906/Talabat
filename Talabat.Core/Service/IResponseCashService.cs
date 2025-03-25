using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Service
{
    public interface IResponseCashService
    {
        //Cash Data 

        Task CasheResponseAsync(string Cashkey, object Responce, TimeSpan ExpireTime);


        //Get Cash Data 


        Task<string?> GetCashResopnse(string Cashkey);

    }
}
