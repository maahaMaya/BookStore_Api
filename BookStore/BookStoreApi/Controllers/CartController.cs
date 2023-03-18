using BusinessLayer.Interface;
using CommonLayer.Models.CartModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Route("addBookInCustomerCart")]
        public IActionResult addBookInCustomerCart(AddBookInCart addBookInCart)
        {
            try
            {
                var result = i_CartBl.addBookInCustomerCart(addBookInCart);
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
        [HttpPost]
        [Route("getBookInCustomerCart")]
        public IActionResult getBookInCustomerCart(GetCustomerId getCustomerId)
        {
            try
            {
                var result = i_CartBl.getBookInCustomerCart(getCustomerId);
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
        public IActionResult updateCustomerCart(GetCartId getCartId)
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
    }
}
