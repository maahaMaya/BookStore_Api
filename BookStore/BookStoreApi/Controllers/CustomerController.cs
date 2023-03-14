using BusinessLayer.Interface;
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
        public IActionResult getAllCustomersDetails()
        {
            try
            {
                var result = i_CustomerBl.getAllCustomer();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Retrieving  successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Retrieving unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
