using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entites
{
    public class Customerbasket
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }


        public Customerbasket(string id)
        {
            id = Id;
        }


        public string? PaymentIntendId { get; set; }
        public string? ClinetSecret { get; set; }

        public int? DeliveryMethod { get; set;  }


    }
}
