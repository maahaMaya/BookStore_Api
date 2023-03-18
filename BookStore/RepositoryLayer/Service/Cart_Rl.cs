using CommonLayer.Models.BookModels;
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
        /// <param name="getCustomerId"></param>
        /// <returns></returns>
        public IEnumerable<GetCartOfCustomer>  getBookInCustomerCart(GetCustomerId getCustomerId)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("spGetBookInCartOfCustomer", sqlConnection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@customer_id", getCustomerId.customer_id);

                this.sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                List<GetCartOfCustomer> getCartOfCustomerList = new List< GetCartOfCustomer>();
                while (rdr.Read())
                {
                    GetCartOfCustomer getCartOfCustomer = new GetCartOfCustomer();

                    getCartOfCustomer.cart_id = Convert.ToInt32(rdr["cart_id"]);
                    getCartOfCustomer.customer_id = Convert.ToInt32(rdr["customer_id"]);
                    getCartOfCustomer.book_id = Convert.ToInt32(rdr["book_id"]);
                    getCartOfCustomer.book_quantity = Convert.ToInt32(rdr["book_quantity"]);

                    getCartOfCustomerList.Add(getCartOfCustomer);
                }
                this.sqlConnection.Close();
                return getCartOfCustomerList;
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

        public bool updateCustomerCart(GetCartId getCartId)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("spUpdateCartBookQuantity", sqlConnection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cart_id", getCartId.cart_id);
                cmd.Parameters.AddWithValue("@book_quantity", getCartId.book_quantity);
                
                sqlConnection.Open();
                int databaseUpdateValue = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if(databaseUpdateValue > 0)
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
    }
}
