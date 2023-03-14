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
        public CustomerRl(IConfiguration iconfiguration) 
        { 
            this.iconfiguration = iconfiguration;
        }

        public IEnumerable<GetAllCustomer> getAllCustomer()
        {
            try
            {
                List<GetAllCustomer> listCustomer = new List<GetAllCustomer>();
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB ;Initial Catalog=BookStore;Integrated Security=True;"))
                {
                    SqlCommand cmd = new SqlCommand("spGetALlCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GetAllCustomer getAllCustomer = new GetAllCustomer();

                        getAllCustomer.customer_id = Convert.ToInt32(rdr["customer_id"]);
                        getAllCustomer.fullname = rdr["fullname"].ToString();
                        getAllCustomer.email_id = rdr["email_id"].ToString();
                        getAllCustomer.passwords = rdr["passwords"].ToString();
                        getAllCustomer.phone_number = Convert.ToInt32(rdr["phone_number"]);

                        listCustomer.Add(getAllCustomer);
                    }
                    con.Close();
                }
                return listCustomer;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
