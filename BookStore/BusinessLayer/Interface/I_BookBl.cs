using CommonLayer.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_BookBl
    {
        public AddNewBook addNewBookByAdmin(AddNewBook addNewBook, string premissionToAddBook);
        public IEnumerable<GetBook> getBookById(GetBookById getBookById);
    }
}
