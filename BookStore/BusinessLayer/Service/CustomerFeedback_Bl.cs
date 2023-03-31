using BusinessLayer.Interface;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.Feedback;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CustomerFeedback_Bl : I_CustomerFeedback_Bl
    {
        I_CustomerFeedback_Rl i_CustomerFeedback_Rl;
        public CustomerFeedback_Bl(I_CustomerFeedback_Rl i_CustomerFeedback_Rl) 
        { 
            this.i_CustomerFeedback_Rl = i_CustomerFeedback_Rl;
        }

        public AddFeedback addCustomerFeedbackForBook(AddFeedback addFeedback, int customer_id)
        {
            try
            {
                return i_CustomerFeedback_Rl.addCustomerFeedbackForBook(addFeedback, customer_id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<GetFeedback> getBookFeedback(GetBookById getBookById)
        {
            try
            {
                return i_CustomerFeedback_Rl.getBookFeedback(getBookById);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
