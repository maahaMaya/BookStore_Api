using BusinessLayer.Interface;
using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("RegisterCustomer")]
        public IActionResult registerNewCustomer(RegisterNewCustomer registerNewCustomer)
        {
            try
            {
                var result = i_CustomerBl.registerNewCustomer(registerNewCustomer);
                if (result != null)
                {
                    return Ok(new { success = true, message = "adding customer successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "adding customer unsuccessful"});
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
                    return Ok(new { success = true, message = "message customer successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "message customer unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
