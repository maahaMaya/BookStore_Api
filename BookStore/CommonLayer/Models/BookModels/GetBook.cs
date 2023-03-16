using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.BookModels
{
    public class GetBook
    {
        public int book_id { get; set; }
        public string book_title { get; set; }
        public string book_author { get; set; }
        public float book_rating { get; set; }
        public int book_total_rating { get; set; }
        public int book_actual_price { get; set; }
        public int book_discount_price { get; set; }
        public string book_description { get; set; }
        public int book_stock { get; set; }
        public string book_image { get; set; }
    }
}
