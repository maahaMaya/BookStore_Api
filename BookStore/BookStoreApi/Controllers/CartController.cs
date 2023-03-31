using BusinessLayer.Interface;
using CommonLayer.Models.CartModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        I_CartBl i_CartBl;
        public CartController(I_CartBl i_CartBl) 
        {
            this.i_CartBl = i_CartBl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addBookInCart"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("addBookInCustomerCart")]
        public IActionResult addBookInCustomerCart(AddBookInCart addBookInCart)
        {
            try
            {
                int customer_id = Convert.ToInt32(User.Claims.FirstOrDefault(cId => cId.Type == "CustomerId").Value);
                var result = i_CartBl.addBookInCustomerCart(addBookInCart, customer_id);
                if(result != null)
                {
                    return Ok(new { success= true, message = "addToCustomer_Success", data = result});
                }
                else
                {
                    return BadRequest(new {success= false, message = "addToCustomer_UnSuccess" });
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
        /// <param name="getCustomerId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getBookInCustomerCart")]
        public IActionResult getBookInCustomerCart()
        {
            try
            {
                int customer_id = Convert.ToInt32(User.Claims.FirstOrDefault(cId => cId.Type == "CustomerId").Value);
                var result = i_CartBl.getBookInCustomerCart(customer_id);
                if (result != null)
                {
                    return Ok(new { success = true, message = "addToCustomer_Success", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "addToCustomer_UnSuccess" });
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
        /// <param name="getCartId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateCustomerCart")]
        public IActionResult updateCustomerCart(UpdateCart getCartId)
        {
            try
            {
                var result = i_CartBl.updateCustomerCart(getCartId);
                if (result == true)
                {
                    return Ok(new { success = true, message = "updateCustomerCart_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "updateCustomerCart_Unsuccessfully" });
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
        /// <param name="getCartId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delteCustomerCart")]
        public IActionResult delteCustomerCart(GetCartId getCartId)
        {
            try
            {
                var result = i_CartBl.delteCustomerCart(getCartId);
                if (result == true)
                {
                    return Ok(new { success = true, message = "delteCustomerCart_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "delteCustomerCart_Unsuccessfully" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
