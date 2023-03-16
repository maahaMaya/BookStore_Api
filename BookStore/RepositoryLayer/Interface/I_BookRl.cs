using CommonLayer.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_BookRl
    {
        public AddNewBook addNewBookByAdmin(AddNewBook addNewBook, string premissionToAddBook);
        public IEnumerable<GetBook> getBookById(GetBookById getBookById);
    }
}
