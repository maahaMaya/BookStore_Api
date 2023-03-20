using BusinessLayer.Interface;
using CommonLayer.Models.AddressModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerAddressController : ControllerBase
    {
        I_CustomerAddress_Bl i_CustomerAddress_Bl;
        public CustomerAddressController(I_CustomerAddress_Bl i_CustomerAddress_Bl) 
        {
            this.i_CustomerAddress_Bl = i_CustomerAddress_Bl;
        }

        [HttpPost]
        [Route("addCustomerAddress")]
        public IActionResult addCustomerAddress(AddCustomerAddress addCustomerAddress)
        {
            try
            {
                var result = i_CustomerAddress_Bl.addCustomerAddress(addCustomerAddress);
                if (result != null)
                {
                    return Ok(new { success = true, message = "addCustomerAddress_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "addCustomerAddress_Unsuccessful" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
