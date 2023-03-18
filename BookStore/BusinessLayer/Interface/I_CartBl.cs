using CommonLayer.Models.CartModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_CartBl
    {
        public AddBookInCart addBookInCustomerCart(AddBookInCart addBookInCart);
        public IEnumerable<GetCartOfCustomer> getBookInCustomerCart(GetCustomerId getCustomerId);
        public bool updateCustomerCart(GetCartId getCartId);
    }
}
