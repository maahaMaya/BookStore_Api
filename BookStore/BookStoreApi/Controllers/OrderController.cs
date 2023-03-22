using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Models.Feedback;
using CommonLayer.Models.OrderModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        I_Order_Bl i_Order_Bl;
        public OrderController(I_Order_Bl i_Order_Bl) 
        {
            this.i_Order_Bl = i_Order_Bl;
        }

        [HttpPost]
        [Route("placeCustomerOder")]
        public IActionResult placeCustomerOder(CreateOrder createOrder)
        {
            try
            {
                var result = i_Order_Bl.placeCustomerOder(createOrder);
                if (result != null)
                {
                    return Ok(new { success = true, message = "placeCustomerOder_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "placeCustomerOder_UnSuccessfully" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
