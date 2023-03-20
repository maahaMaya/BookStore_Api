using CommonLayer.Models.CartModels;
using CommonLayer.Models.Wishlist;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class Wishlist_Rl : I_Wishlist_Rl
    {
        public readonly string _connectionString;
        SqlConnection sqlConnection;
        public Wishlist_Rl(IConfiguration iconfiguration) 
        {
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addWishlist"></param>
        /// <returns></returns>
        public AddWishlist addCustomerBookToWishlist(AddWishlist addWishlist)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spAddBookInWishlist", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@customer_id", addWishlist.customer_id);
                sqlCommand.Parameters.AddWithValue("@book_id", addWishlist.book_id);

                this.sqlConnection.Open();
                int databaseUpdateValue = sqlCommand.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (databaseUpdateValue>= 1)
                {
                    return addWishlist;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getWishlistId"></param>
        /// <returns></returns>
        public bool deleteCustomerBookToWishlist(GetWishlistId getWishlistId)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spDeleteBookInCustomerWishlist", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@wishlist_id", getWishlistId.wishlist_id);

                this.sqlConnection.Open();
                int databaseUpdateValue = sqlCommand.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (databaseUpdateValue >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
