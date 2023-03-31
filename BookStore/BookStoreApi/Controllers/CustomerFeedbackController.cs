using BusinessLayer.Interface;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.CartModels;
using CommonLayer.Models.Feedback;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFeedbackController : ControllerBase
    {
        I_CustomerFeedback_Bl i_CustomerFeedback_Bl;
        public CustomerFeedbackController(I_CustomerFeedback_Bl i_CustomerFeedback_Bl) 
        {
            this.i_CustomerFeedback_Bl = i_CustomerFeedback_Bl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addFeedback"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("addCustomerFeedbackForBook")]
        public IActionResult addCustomerFeedbackForBook(AddFeedback addFeedback)
        {
            try
            {
                int customer_id = Convert.ToInt32(User.Claims.FirstOrDefault(cId => cId.Type == "CustomerId").Value);
                var result = i_CustomerFeedback_Bl.addCustomerFeedbackForBook(addFeedback, customer_id);
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
