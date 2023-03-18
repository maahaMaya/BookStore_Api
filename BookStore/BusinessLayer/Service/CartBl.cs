using BusinessLayer.Interface;
using CommonLayer.Models.CartModels;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBl : I_CartBl
    {
        I_CartRl i_CartRl;
        public CartBl(I_CartRl i_CartRl) 
        {
            this.i_CartRl= i_CartRl;
        }

        public AddBookInCart addBookInCustomerCart(AddBookInCart addBookInCart)
        {
            try
            {
                return i_CartRl.addBookInCustomerCart(addBookInCart);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetCartOfCustomer> getBookInCustomerCart(GetCustomerId getCustomerId)
        {
            try
            {
                return i_CartRl.getBookInCustomerCart(getCustomerId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool updateCustomerCart(UpdateCart getCartId)
        {
            try
            {
                return i_CartRl.updateCustomerCart(getCartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool delteCustomerCart(GetCartId getCartId)
        {
            try
            {
                return i_CartRl.delteCustomerCart(getCartId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
