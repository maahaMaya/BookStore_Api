using CommonLayer.Models.BookModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_BookBl
    {
        public AddNewBook addNewBookByAdmin(AddNewBook addNewBook, string premissionToAddBook);
        public IEnumerable<GetBook> getBookById(GetBookById getBookById);
        public IEnumerable<GetBook> getAllBook();
        public bool BookImageUpdate(UpdateBookImage updateBookImage);
    }
}
