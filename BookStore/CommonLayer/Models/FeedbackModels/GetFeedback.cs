using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Feedback
{
    public class GetFeedback
    {
        public int feedback_id { get; set; }
        public string fullname { get; set; }
        public int customer_id { get; set; }
        public int book_id { get; set; }
        public float feedback_rating { get; set; }
        public string feedback_comment { get; set; }
    }
}
