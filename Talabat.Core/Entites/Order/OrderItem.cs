using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entites.Order
{
    public class OrderItem : BaseEntity
    {

        public OrderItem()
        {

        }
        public OrderItem(ProductItemOrdered product, decimal price, int quantity)
        {
            this.product = product;
            this.price = price;
            Quantity = quantity;
        }

        public ProductItemOrdered product { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }


    }
}
