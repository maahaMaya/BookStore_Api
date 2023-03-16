using BusinessLayer.Interface;
using CommonLayer.Models.BookModels;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBl : I_BookBl
    {
        I_BookRl i_BookRl;
        public BookBl(I_BookRl i_BookRl) 
        {
            this.i_BookRl = i_BookRl;
        }

        public AddNewBook addNewBookByAdmin(AddNewBook addNewBook, string premissionToAddBook)
        {
            try
            {
                return i_BookRl.addNewBookByAdmin(addNewBook, premissionToAddBook);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetBook> getBookById(GetBookById getBookById)
        {
            try
            {
                return i_BookRl.getBookById(getBookById);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
