using BusinessLayer.Interface;
using CommonLayer.Models.CartModels;
using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        I_CustomerBl i_CustomerBl;
        public CustomerController(I_CustomerBl i_CustomerBl) 
        {   
           this.i_CustomerBl= i_CustomerBl;
        }

        [HttpGet]
        [Route("RetrieveCustomer")]
        public IActionResult getAllCustomersDetails()
        {
            try
            {
                var result = i_CustomerBl.getAllCustomer();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Retrieving customer successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Retrieving customer unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("getAllCustomersDetailById")]
        public IActionResult getAllCustomersDetailById(GetCustomerId getCustomerId)
        {
            try
            {
                var result = i_CustomerBl.getCustomerById(getCustomerId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Retrieving customer successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Retrieving customer unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("RegisterCustomer")]
        public IActionResult registerNewCustomer(RegisterNewCustomer registerNewCustomer)
        {
            try
            {
                var result = i_CustomerBl.registerNewCustomer(registerNewCustomer);
                if (result != null)
                {
                    return Ok(new { success = true, message = "addingCustomer_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "addingCustomer_Unsuccessful"});
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("loginCustomer")]
        public IActionResult loginCustomer(LoginCustomer loginCustomer)
        {
            try
            {
                var result = i_CustomerBl.login_Customer(loginCustomer);
                if (result != null)
                {
                    return Ok(new { success = true, message = "loginCustomer_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "loginCustomer_Unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("forgetLoginPassword")]
        public IActionResult foegetLoginPassword(ForgetPassword forgetPassword)
        {
            try
            {
                var result = i_CustomerBl.forget_login_password(forgetPassword);
                if (result != null)
                {
                    return Ok(new { success = true, message = "forgetMessageSendToCustomer_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "forgetMessageSendToCustomer_Unsuccessfully" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("resetLoginPassword")]
        public IActionResult resetLoginPassword(ResetPassword resetPassword)
        {
            try
            {
                var email_id = User.FindFirst(ClaimTypes.Email).Value.ToString(); 
                var result = i_CustomerBl.reset_login_password(resetPassword, email_id);
                if (result == true)
                {
                    return Ok(new { success = true, message = "passwordReset_successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "passwordReset_Unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
