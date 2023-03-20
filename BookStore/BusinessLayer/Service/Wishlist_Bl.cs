using BusinessLayer.Interface;
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

        public AddWishlist addCustomerBookToWishlist(AddWishlist addWishlist)
        {
            try
            {
                return i_Wishlist_Rl.addCustomerBookToWishlist(addWishlist);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
