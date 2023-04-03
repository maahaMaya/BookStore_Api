using BusinessLayer.Interface;
using CommonLayer.Models.CartModels;
using CommonLayer.Models.Wishlist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = Role.Customer)]
        [HttpPost]
        [Route("addCustomerBookToWishlist")]
        public IActionResult addCustomerBookToWishlist(AddWishlist addWishlist)
        {
            try
            {
                int customer_id = Convert.ToInt32(User.Claims.FirstOrDefault(cId => cId.Type == "CustomerId").Value);
                var result = i_Wishlist_Bl.addCustomerBookToWishlist(addWishlist, customer_id);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getWishlistId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("deleteCustomerBookToWishlist")]
        public IActionResult deleteCustomerBookToWishlist(GetWishlistId getWishlistId)
        {
            try
            {
                if (getWishlistId == null)
                {
                    return BadRequest(new { success = false });
                }
                var result = i_Wishlist_Bl.deleteCustomerBookToWishlist(getWishlistId);
                try
                {
                    if (result == true)
                    {
                        return Ok(new { success = true, message = "deleteCustomerBookToWishlist_Successfully", data = result });
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "deleteCustomerBookToWishlist_Unsuccessfully" });
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getWishlistId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getCustomerBookToWishlist")]
        public IActionResult getCustomerBookToWishlist()
        {
            try
            {
                int customer_id = Convert.ToInt32(User.Claims.FirstOrDefault(cId => cId.Type == "CustomerId").Value);
                var result = i_Wishlist_Bl.getAllCustomerBookWishlist(customer_id);
                try
                {
                    if (result != null)
                    {
                        return Ok(new { success = true, message = "getCustomerBookToWishlist_Successfully", data = result });
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "getCustomerBookToWishlist_Unsuccessfully" });
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
