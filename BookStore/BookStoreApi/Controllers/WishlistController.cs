using BusinessLayer.Interface;
using CommonLayer.Models.Wishlist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        I_Wishlist_Bl i_Wishlist_Bl;
        public WishlistController(I_Wishlist_Bl i_Wishlist_Bl) 
        {
            this.i_Wishlist_Bl = i_Wishlist_Bl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addWishlist"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addCustomerBookToWishlist")]
        public IActionResult addCustomerBookToWishlist(AddWishlist addWishlist)
        {
            try
            {
                if(addWishlist == null)
                {
                    return BadRequest(new { success = false });
                }
                var result = i_Wishlist_Bl.addCustomerBookToWishlist(addWishlist);
                try
                {
                    if(result != null)
                    {
                        return Ok(new {success = true, message = "addCustomerBookToWishlist_Successfully" ,data = result});
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "addCustomerBookToWishlist_Unsuccessfully" });
                    }
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
