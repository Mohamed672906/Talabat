using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites.Order;

namespace Talabat.Core.Specifications.OrderSpecifications
{
    public class OrderSpecification : BaseSepecification<Order>
    {

        public OrderSpecification(string email) : base(O => O.BuyerEmail == email)
        {
            Includes.Add(O => O.Items);
            Includes.Add(O => O.DeliveryMethod);
            AddOrderByDescending(O => O.OrderDate);

        }
        public OrderSpecification(string email, int orderId) : base(O => O.BuyerEmail == email && O.Id == orderId)
        {
            Includes.Add(O => O.Items);
            Includes.Add(O => O.DeliveryMethod);

        }





    }
}
