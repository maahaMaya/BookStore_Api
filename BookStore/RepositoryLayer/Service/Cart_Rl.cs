using CommonLayer.Models.CartModels;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class Cart_Rl : I_CartRl
    {
        private readonly string _connectionString;
        SqlConnection sqlConnection;
        public Cart_Rl(IConfiguration iconfiguration) 
        {
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addBookInCart"></param>
        /// <returns></returns>
        public AddBookInCart addBookInCustomerCart(AddBookInCart addBookInCart)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("spAddBookInCart", sqlConnection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customer_id", addBookInCart.customer_id);
                cmd.Parameters.AddWithValue("@book_id", addBookInCart.book_id);
                cmd.Parameters.AddWithValue("@book_quantity", addBookInCart.book_quantity);

                this.sqlConnection.Open();
                int databaseUpdateValue = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if(databaseUpdateValue >= 1)
                {
                    return addBookInCart;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
