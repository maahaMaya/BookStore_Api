using CommonLayer.Models.AddressModel;
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
    public class CustomerAddress_Rl : I_CustomerAddress_Rl
    {
        private readonly string _connectionString;
        SqlConnection sqlConnection;
        public CustomerAddress_Rl(IConfiguration iconfiguration) 
        {
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addCustomerAddress"></param>
        /// <returns></returns>
        public AddCustomerAddress addCustomerAddress(AddCustomerAddress addCustomerAddress)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spAddUpdateCustomerAddress", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@customer_id", addCustomerAddress.customer_id);
                sqlCommand.Parameters.AddWithValue("@address_type_id", addCustomerAddress.address_type_id);
                sqlCommand.Parameters.AddWithValue("@customer_address", addCustomerAddress.customer_address);
                sqlCommand.Parameters.AddWithValue("@customer_city", addCustomerAddress.customer_city);
                sqlCommand.Parameters.AddWithValue("@customer_state", addCustomerAddress.customer_state);

                this.sqlConnection.Open();
                int databaseUpdateValue = sqlCommand.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (databaseUpdateValue >= 1)
                {
                    return addCustomerAddress;
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
        /// <param name="getAddressId"></param>
        /// <returns></returns>
        public bool deleteCustomerAddress(GetAddressId getAddressId)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                SqlCommand sqlCommand = new SqlCommand("spDeleteCustomerAddress", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@address_id", getAddressId.address_id);

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
    }
}
