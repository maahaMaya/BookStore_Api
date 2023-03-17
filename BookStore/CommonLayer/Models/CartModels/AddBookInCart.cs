using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.CartModels
{
    public class AddBookInCart
    {
        public int customer_id { get; set; }
        public int book_id { get; set; }
        public int book_quantity { get; set; }
    }
}
