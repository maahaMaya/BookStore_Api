using CommonLayer.Models.AddressModel;
using CommonLayer.Models.BookModels;
using CommonLayer.Models.CartModels;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getCustomerId"></param>
        /// <returns></returns>
        public IEnumerable<GetCustomerAddress> getCustomerAddress(GetCustomerId getCustomerId)
        {
            try
            {
                sqlConnection = new SqlConnection(_connectionString);
                List<GetCustomerAddress> getCustomerAddressesList = new List<GetCustomerAddress>();
                SqlCommand cmd = new SqlCommand("spGetCustomerAddress", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@customer_id", getCustomerId.customer_id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                while (rdr.Read())
                {
                    GetCustomerAddress getCustomerAddress = new GetCustomerAddress();

                    getCustomerAddress.fullname = rdr["fullname"].ToString();
                    getCustomerAddress.phone_number = Convert.ToInt32(rdr["phone_number"]);
                    getCustomerAddress.address_id = Convert.ToInt32(rdr["address_id"]);
                    getCustomerAddress.customer_id = Convert.ToInt32(rdr["customer_id"]);
                    getCustomerAddress.address_type_id = Convert.ToInt32(rdr["address_type_id"]);
                    getCustomerAddress.customer_address = rdr["customer_address"].ToString();
                    getCustomerAddress.customer_city = rdr["customer_city"].ToString();
                    getCustomerAddress.customer_state = rdr["customer_state"].ToString();

                    getCustomerAddressesList.Add(getCustomerAddress);
                }
                sqlConnection.Close();
                return getCustomerAddressesList;
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
