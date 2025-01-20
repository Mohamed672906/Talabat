using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites.Order;
using Talabat.Core.Entites;
using Talabat.Core.Service;

namespace Talabat.Servicse
{

    public class OrderService : IOrderService
    {
        public Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, int DeliveryMethodId, Address ShippingAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdForSpecificUserAsync(string buyerEmail, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
