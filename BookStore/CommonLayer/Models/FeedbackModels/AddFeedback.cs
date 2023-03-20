using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Feedback
{
    public class AddFeedback
    {
        public int customer_id { get; set; }
        public int book_id { get; set; }
        public string feedback_rating { get; set; }
        public string feedback_comment { get; set; }
    }
}
