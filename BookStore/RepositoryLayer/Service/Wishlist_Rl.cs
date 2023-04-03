using CommonLayer.Models.BookModels;
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
        public AddWishlist addCustomerBookToWishlist(AddWishlist addWishlist, int customer_id)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spAddBookInWishlist", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@customer_id", customer_id);
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
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
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
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public IEnumerable<GetWishlist> getAllCustomerBookWishlist(int customer_id)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                List<GetWishlist> getWishCustomerlists = new List<GetWishlist>();
                SqlCommand cmd = new SqlCommand("spGetBookInCustomerWishlist", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customer_id", customer_id);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    ;
                }
                while (rdr.Read())
                {
                    GetWishlist getWishlist = new GetWishlist();

                    getWishlist.wishlist_id = Convert.ToInt32(rdr["wishlist_id"]);
                    getWishlist.customer_id = Convert.ToInt32(rdr["customer_id"]);
                    getWishlist.book_id = Convert.ToInt32(rdr["book_id"]);
                    getWishlist.book_title = rdr["book_title"].ToString();
                    getWishlist.book_author = rdr["book_author"].ToString();
                    getWishlist.book_rating = Convert.ToSingle(rdr["book_rating"]);
                    getWishlist.book_total_rating = Convert.ToInt32(rdr["book_total_rating"]);
                    getWishlist.book_actual_price = Convert.ToInt32(rdr["book_actual_price"]);
                    getWishlist.book_discount_price = Convert.ToInt32(rdr["book_discount_price"]);
                    getWishlist.book_description = rdr["book_description"].ToString();
                    getWishlist.book_stock = Convert.ToInt32(rdr["book_stock"]);
                    getWishlist.book_image = rdr["book_image"].ToString();

                    getWishCustomerlists.Add(getWishlist);
                }
                sqlConnection.Close();
                return getWishCustomerlists;
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
