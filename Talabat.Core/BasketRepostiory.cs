using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using Talabat.Core.Entites;
using Talabat.Core.Repositories;

namespace Talabat.Core
{
    public class BasketRepostiory : IBaskedReopsitory
    {
        private readonly IDatabase _database;

        public BasketRepostiory(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }



        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
            return await _database.KeyDeleteAsync(BasketId);
        }

        public async Task<Customerbasket?> GetBasketAsync(string BasketId)
        {
            var Basket = await _database.StringGetAsync(BasketId);

            return Basket.IsNull ? null : JsonSerializer.Deserialize<Customerbasket>(Basket);
        }

        public async Task<Customerbasket?> UpdateBasketAsync(Customerbasket Basket)
        {
            var JsonBasket = JsonSerializer.Serialize(Basket);
            var CreatedOrUpdated = await _database.StringSetAsync(Basket.Id, JsonBasket, TimeSpan.FromDays(1));
            if (!CreatedOrUpdated) return null;
            return await GetBasketAsync(Basket.Id);

        }
    }
}
