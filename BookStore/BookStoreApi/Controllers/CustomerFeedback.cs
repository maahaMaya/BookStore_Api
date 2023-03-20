using BusinessLayer.Interface;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.CartModels;
using CommonLayer.Models.Feedback;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFeedback : ControllerBase
    {
        I_CustomerFeedback_Bl i_CustomerFeedback_Bl;
        public CustomerFeedback(I_CustomerFeedback_Bl i_CustomerFeedback_Bl) 
        {
            this.i_CustomerFeedback_Bl = i_CustomerFeedback_Bl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addFeedback"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addCustomerBookToWishlist")]
        public IActionResult addCustomerBookToWishlist(AddFeedback addFeedback)
        {
            try
            {
                var result = i_CustomerFeedback_Bl.addCustomerBookToWishlist(addFeedback);
                if (result != null)
                {
                    return Ok(new { success = true, message = "addCustomerBookToWishlist_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "addCustomerBookToWishlist_UnSuccessfully" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("getBookFeedback")]
        public IActionResult getBookFeedback([FromQuery]GetBookById getBookById)
        {
            try
            {
                var result = i_CustomerFeedback_Bl.getBookFeedback(getBookById);
                if (result != null)
                {
                    return Ok(new { success = true, message = "getBookFeedback_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "getBookFeedback_UnSuccessfully" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        
    }
}
