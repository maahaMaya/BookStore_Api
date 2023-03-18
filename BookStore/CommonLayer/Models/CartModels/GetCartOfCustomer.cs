using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.CartModels
{
    public class GetCartOfCustomer
    {
        public int cart_id { get; set; }
        public int customer_id { get; set; }
        public int book_id { get; set; }
        public int book_quantity { get; set; }
    }
}
