using BusinessLayer.Interface;
using CommonLayer.Models.AdminModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        I_AdminBl i_AdminBl;
        public AdminController(I_AdminBl i_AdminBl) 
        {
            this.i_AdminBl = i_AdminBl;
        }

        [HttpPost]
        [Route("loginAdmin")]
        public IActionResult login_Admin(LoginAdmin loginAdmin)
        {
            try
            {
                var result = i_AdminBl.login_Admin(loginAdmin);
                if (result != null)
                {
                    return Ok(new { success = true, message = "loginAdmin_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "loginAdmin_Unsuccessful" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
