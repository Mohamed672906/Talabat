using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites.Order;
using Talabat.Core.Entites;
using Talabat.Core.Service;
using Talabat.Core.Repositories;
using Talabat.Core;

namespace Talabat.Servicse
{

    public class OrderService : IOrderService
    {
        private readonly IBaskedReopsitory _baskedReopsitory;
        private readonly IGenericRepository<Product> _productRepp;
        private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepo;
        private readonly IGenericRepository<Order> _orderRepo;

        public OrderService(IBaskedReopsitory baskedReopsitory ,
            IGenericRepository<Product> ProductRepp,
            IGenericRepository<DeliveryMethod> deliveryMethodRepo,
            IGenericRepository<Order> orderRepo)
        {
            _baskedReopsitory = baskedReopsitory;
            _productRepp = ProductRepp;
            _deliveryMethodRepo = deliveryMethodRepo;
            _orderRepo = orderRepo;
        }


        public async Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, int DeliveryMethodId, Address ShippingAddress)
        {
            //1.Get Basket From Basket Repo
            var Basket = await _baskedReopsitory.GetBasketAsync(basketId);
            // 2.Get Selected Items at Basket From Product Repo
            var OrderItems = new List<OrderItem>();
            if (Basket?.Items.Count > 0)
            {
                foreach (var item in OrderItems)
                {
                    var product = await _productRepp.GetByIdAsync(item.Id);
                    var ProductItemOrder = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);
                    var orderItem = new OrderItem(ProductItemOrder, item.price, item.Quantity);
                    OrderItems.Add(orderItem);
                }
            }
            // 3.Calculate SubTotal
            var SubTotal = OrderItems.Sum(item => item.price * item.Quantity);
            // 4.Get Delivery Method From DeliveryMethod Repo
            var DeliveryMethod = await _deliveryMethodRepo.GetByIdAsync(DeliveryMethodId);
            // 5.Create Order
            var Order = new Order(buyerEmail, ShippingAddress, DeliveryMethod, OrderItems, SubTotal);
            // 6.Add Order Locally
            await _orderRepo.AddAsync(Order);
            // 7.Save Order To Database[ToDo]
            //var result = await _productRepp.CompleteAsync();
            //if (result <= 0) return null;
            //return Order;
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
}
