using CommonLayer.Models.OrderModel;
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
    public class Order_Rl : I_Order_Rl
    {
        public readonly string _connectionString;
        SqlConnection sqlConnection;
        public Order_Rl(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;
        }

        public CreateOrder placeCustomerOder(CreateOrder createOrder)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spCreateOrder", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@customer_id", createOrder.customer_id);
                sqlCommand.Parameters.AddWithValue("@book_id", createOrder.book_id);
                sqlCommand.Parameters.AddWithValue("@address_id", createOrder.address_id);

                this.sqlConnection.Open();
                int databaseUpdateValue = sqlCommand.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (databaseUpdateValue >= 1)
                {
                    return createOrder;
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
