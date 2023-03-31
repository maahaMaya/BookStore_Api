using CommonLayer.Models.CartModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_CartBl
    {
        public AddBookInCart addBookInCustomerCart(AddBookInCart addBookInCart, int customer_id);
        public IEnumerable<GetCartOfCustomer> getBookInCustomerCart(int customer_id);
        public bool updateCustomerCart(UpdateCart updateCart);

        public bool delteCustomerCart(GetCartId getCartId);
    }
}
