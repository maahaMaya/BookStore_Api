using BusinessLayer.Interface;
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

        public AddFeedback addCustomerBookToWishlist(AddFeedback addFeedback)
        {
            try
            {
                return i_CustomerFeedback_Rl.addCustomerBookToWishlist(addFeedback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
