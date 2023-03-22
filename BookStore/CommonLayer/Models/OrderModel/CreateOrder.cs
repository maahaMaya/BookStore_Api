using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.OrderModel
{
    public class CreateOrder
    {
        public int customer_id { get; set; }
        public int book_id { get; set; }
        public int address_id { get; set; }
    }
}
