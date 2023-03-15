using BusinessLayer.Interface;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.CustomerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStoreApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        I_BookBl i_BookBl;
        public BookController(I_BookBl i_BookBl) 
        {
            this.i_BookBl = i_BookBl;
        }

        [HttpPost]
        [Route("addNewBookByAdmin")]
        public IActionResult addNewBookByAdmin(AddNewBook addNewBook)
        {
            try
            {
                var premissionToAddBook = User.FindFirst(ClaimTypes.Role).Value.ToString();
                var result = i_BookBl.addNewBookByAdmin(addNewBook, premissionToAddBook);
                if (result != null)
                {
                    return Ok(new { success = true, message = "addingBook_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "addingBook_Unsuccessful", data = premissionToAddBook });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
