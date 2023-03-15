using CommonLayer.Models.AdminModel;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.CustomerModels;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class BookRl : I_BookRl
    {
        private readonly string _connectionString;
        SqlConnection sqlConnection;
        private static readonly string roleCheckForAddBook = "Admin";
        public BookRl(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;
        }

        public AddNewBook addNewBookByAdmin(AddNewBook addNewBook, string premissionToAddBook)
        {
            sqlConnection = new SqlConnection(_connectionString);
            try
            {
                if (premissionToAddBook == roleCheckForAddBook)
                {
                    SqlCommand cmd = new SqlCommand("spAddNewBook", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@book_title", addNewBook.book_title);
                    cmd.Parameters.AddWithValue("@book_author", addNewBook.book_author);
                    cmd.Parameters.AddWithValue("@book_rating", addNewBook.book_rating);
                    cmd.Parameters.AddWithValue("@book_total_rating", addNewBook.book_total_rating);
                    cmd.Parameters.AddWithValue("@book_actual_price", addNewBook.book_actual_price);
                    cmd.Parameters.AddWithValue("@book_discount_price", addNewBook.book_discount_price);
                    cmd.Parameters.AddWithValue("@book_description", addNewBook.book_description);
                    cmd.Parameters.AddWithValue("@book_stock", addNewBook.book_stock);
                    cmd.Parameters.AddWithValue("@book_image", addNewBook.book_image);

                    this.sqlConnection.Open();
                    int databaseUpdateValue = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (databaseUpdateValue >= 1)
                    {
                        return addNewBook;
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
