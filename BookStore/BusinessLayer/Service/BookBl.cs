using BusinessLayer.Interface;
using CommonLayer.Models.BookModels;
using Microsoft.AspNetCore.Http;
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

        public GetBook getBookById(GetBookById getBookById)
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

        public IEnumerable<GetBook> getAllBook()
        {
            try
            {
                return i_BookRl.getAllBook();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool BookImageUpdate(UpdateBookImage updateBookImage)
        {
            try
            {
                return i_BookRl.BookImageUpdate(updateBookImage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UpdateBook updateBookByAdmin(UpdateBook updateBook)
        {
            try
            {
                return i_BookRl.updateBookByAdmin(updateBook);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
