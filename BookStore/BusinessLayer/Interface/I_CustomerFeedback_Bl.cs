using CommonLayer.Models.BookModels;
using CommonLayer.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_CustomerFeedback_Bl
    {
        public AddFeedback addCustomerFeedbackForBook(AddFeedback addFeedback, int customer_id);
        public IEnumerable<GetFeedback> getBookFeedback(GetBookById getBookById);
    }
}
