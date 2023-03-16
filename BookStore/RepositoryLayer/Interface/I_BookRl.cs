using CommonLayer.Models.BookModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_BookRl
    {
        public AddNewBook addNewBookByAdmin(AddNewBook addNewBook, string premissionToAddBook);
        public GetBook getBookById(GetBookById getBookById);
        public IEnumerable<GetBook> getAllBook();
        public bool BookImageUpdate(UpdateBookImage updateBookImage);
        public UpdateBook updateBookByAdmin(UpdateBook updateBook);
    }
}
