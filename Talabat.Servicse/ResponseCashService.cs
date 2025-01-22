using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using Talabat.Core.Service;

namespace Talabat.Servicse
{
    public class ResponseCashService : IResponseCashService
    {
        private readonly IDatabase _database;

        public ResponseCashService(IConnectionMultiplexer Redis)
        {
            _database = Redis.GetDatabase();

        }


        public async Task CasheResponseAsync(string Cashkey, object Responce, TimeSpan ExpireTime)
        {
            if (Responce is null) return;
            var Options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var SerilzedResopnse = JsonSerializer.Serialize(Responce, Options);

            await _database.StringSetAsync(Cashkey, SerilzedResopnse, ExpireTime);


        }

        public async Task<string> GetCashResopnse(string Cashkey)
        {
            var CasheResopnse = await _database.StringGetAsync(Cashkey);
            if (CasheResopnse.IsNullOrEmpty) return null;
            return CasheResopnse;
        }
    }
}
