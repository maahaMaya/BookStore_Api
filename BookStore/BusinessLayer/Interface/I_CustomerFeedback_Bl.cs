using CommonLayer.Models.BookModels;
using CommonLayer.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_CustomerFeedback_Bl
    {
        public AddFeedback addCustomerBookToWishlist(AddFeedback addFeedback);
        public IEnumerable<GetFeedback> getBookFeedback(GetBookById getBookById);
    }
}
