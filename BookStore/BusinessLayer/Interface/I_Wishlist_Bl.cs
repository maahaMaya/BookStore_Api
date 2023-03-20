using CommonLayer.Models.Wishlist;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_Wishlist_Bl
    {
        public AddWishlist addCustomerBookToWishlist(AddWishlist addWishlist);
    }
}
