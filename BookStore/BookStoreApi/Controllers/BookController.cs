using BusinessLayer.Interface;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.CustomerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStoreApi.Controllers
{
    //[Authorize]
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
                    return BadRequest(new { success = false, message = "addingBook_Unsuccessful"});
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize]
        [HttpGet]
        [Route("getBookById")]
        public IActionResult getBookById([FromQuery] GetBookById getBookById)
        {
            try
            {
                var result = i_BookBl.getBookById(getBookById);
                if (result != null)
                {
                    return Ok(new { success = true, message = "reteriveBook_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "reteriveBook_Unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpGet]
        [Route("getAllBook")]
        public IActionResult getAllBook()
        {
            try
            {
                var result = i_BookBl.getAllBook();
                if (result != null)
                {
                    return Ok(new { success = true, message = "reteriveAllBook_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "reteriveAllBook_Unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("upadeBookImage")]
        public IActionResult upadeBookImage([FromForm] UpdateBookImage updateBookImage) 
        { 
            try
            {
                var result = i_BookBl.BookImageUpdate(updateBookImage);
                if (result == true)
                {
                    return Ok(new { success = true, message = "updateBookImage_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "updateBookImage_Unsuccessful", data = result });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("upadeBookByAdmins")]
        public IActionResult upadeBookByAdmins(UpdateBook updateBook)
        {
            try
            {
                //var resultBook = i_BookBl.getBookById(getBookById);
                //if (addNewBook.book_description == string.Empty)
                //{
                //    addNewBook.book_description = resultBook.book_description;
                //}

                var result = i_BookBl.updateBookByAdmin(updateBook);
                if (result != null)
                {
                    return Ok(new { success = true, message = "updateBookDetails_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "updateBookDetails_Unsuccessful", data = result });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("deleteBookByAdmins")]
        public IActionResult deleteBookByAdmins(GetBookById getBookById)
        {
            try
            {
                var result = i_BookBl.delteBookByAdmin(getBookById);
                if (result == true)
                {
                    return Ok(new { success = true, message = "deleteBook_Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "deleteBook_Unsuccessful", data = result });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
