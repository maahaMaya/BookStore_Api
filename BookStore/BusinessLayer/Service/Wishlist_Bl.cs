using BusinessLayer.Interface;
using CommonLayer.Models.CartModels;
using CommonLayer.Models.Wishlist;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class Wishlist_Bl : I_Wishlist_Bl
    {
        I_Wishlist_Rl i_Wishlist_Rl;
        public Wishlist_Bl(I_Wishlist_Rl i_Wishlist_Rl) 
        {
            this.i_Wishlist_Rl = i_Wishlist_Rl;
        }

        public AddWishlist addCustomerBookToWishlist(AddWishlist addWishlist, int customer_id)
        {
            try
            {
                return i_Wishlist_Rl.addCustomerBookToWishlist(addWishlist, customer_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool deleteCustomerBookToWishlist(GetWishlistId getWishlistId)
        {
            try
            {
                return i_Wishlist_Rl.deleteCustomerBookToWishlist(getWishlistId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetWishlist> getAllCustomerBookWishlist(int customer_id)
        {
            try
            {
                return i_Wishlist_Rl.getAllCustomerBookWishlist(customer_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
