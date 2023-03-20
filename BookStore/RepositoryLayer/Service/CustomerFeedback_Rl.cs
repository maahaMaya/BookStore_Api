using CommonLayer.Models.Feedback;
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
    public class CustomerFeedback_Rl : I_CustomerFeedback_Rl
    {
        public readonly string _connectionString;
        SqlConnection sqlConnection;
        public CustomerFeedback_Rl(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addFeedback"></param>
        /// <returns></returns>
        public AddFeedback addCustomerBookToWishlist(AddFeedback addFeedback)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spAddCustomerFeedback", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@customer_id", addFeedback.customer_id);
                sqlCommand.Parameters.AddWithValue("@book_id", addFeedback.book_id);
                sqlCommand.Parameters.AddWithValue("@feedback_rating", addFeedback.feedback_rating);
                sqlCommand.Parameters.AddWithValue("@feedback_comment", addFeedback.feedback_comment);

                this.sqlConnection.Open();
                int databaseUpdateValue = sqlCommand.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (databaseUpdateValue >= 1)
                {
                    return addFeedback;
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
    }
}
