using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.UserModels;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CustomerRl : I_CustomerRl
    {
        private readonly IConfiguration iconfiguration;

        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB ;Initial Catalog=BookStore;Integrated Security=True;";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public CustomerRl(IConfiguration iconfiguration) 
        { 
            this.iconfiguration = iconfiguration;
        }

        public IEnumerable<GetAllCustomer> getAllCustomer()
        {
            try
            {
                List<GetAllCustomer> listCustomer = new List<GetAllCustomer>();
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spGetALlCustomer", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GetAllCustomer getAllCustomer = new GetAllCustomer();

                        getAllCustomer.customer_id = Convert.ToInt32(rdr["customer_id"]);
                        getAllCustomer.fullname = rdr["fullname"].ToString();
                        getAllCustomer.email_id = rdr["email_id"].ToString();
                        getAllCustomer.passwords = rdr["passwords"].ToString();
                        getAllCustomer.phone_number = Convert.ToInt32(rdr["phone_number"]);
                        getAllCustomer.created_at = Convert.ToDateTime(rdr["created_at"]);

                        listCustomer.Add(getAllCustomer);
                    }
                    sqlConnection.Close();
                }
                return listCustomer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RegisterNewCustomer registerNewCustomer(RegisterNewCustomer registerNewCustomer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spRegisterNewCustomer", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fullname", registerNewCustomer.fullname);
                cmd.Parameters.AddWithValue("@email_id", registerNewCustomer.email_id);
                cmd.Parameters.AddWithValue("@passwords", registerNewCustomer.passwords);
                cmd.Parameters.AddWithValue("@phone_number", registerNewCustomer.phone_number);

                this.sqlConnection.Open();
                int databaseUpdateValue = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if(databaseUpdateValue >= 1)
                {
                    return registerNewCustomer;
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
