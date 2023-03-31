using CommonLayer.Models.BookModels;
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
        public AddFeedback addCustomerFeedbackForBook(AddFeedback addFeedback, int customer_id)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spAddCustomerFeedback", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@customer_id", customer_id);
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GetFeedback> getBookFeedback(GetBookById getBookById)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                List<GetFeedback> getFeedbacksList = new List<GetFeedback>();
                SqlCommand cmd = new SqlCommand("spGetCustomerFeedback", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                


                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@book_id", getBookById.book_id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                while (rdr.Read())
                {
                    GetFeedback getBookFeedback = new GetFeedback();

                    getBookFeedback.feedback_id = Convert.ToInt32(rdr["feedback_id"]);
                    getBookFeedback.customer_id = Convert.ToInt32(rdr["customer_id"]);
                    getBookFeedback.book_id = Convert.ToInt32(rdr["book_id"]);
                    getBookFeedback.feedback_rating = Convert.ToSingle(rdr["feedback_rating"]);
                    getBookFeedback.fullname = rdr["fullname"].ToString();
                    getBookFeedback.feedback_comment = rdr["feedback_comment"].ToString();

                    getFeedbacksList.Add(getBookFeedback);
                }
                sqlConnection.Close();
                return getFeedbacksList;
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
