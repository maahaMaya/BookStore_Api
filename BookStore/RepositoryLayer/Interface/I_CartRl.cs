using CommonLayer.Models.CartModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_CartRl
    {
        public AddBookInCart addBookInCustomerCart(AddBookInCart addBookInCart);
        public IEnumerable<GetCartOfCustomer> getBookInCustomerCart(GetCustomerId getCustomerId);
    }
}
