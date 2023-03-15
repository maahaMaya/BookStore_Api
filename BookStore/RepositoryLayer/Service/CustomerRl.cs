using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.MsmqModel;
using CommonLayer.Models.UserModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CustomerRl : I_CustomerRl
    {
        private readonly IConfiguration iconfiguration;

        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB ;Initial Catalog=BookStore;Integrated Security=True;";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        private readonly string _secret;
        private readonly string _expDate;
        public CustomerRl(IConfiguration iconfiguration) 
        { 
            this.iconfiguration = iconfiguration;
            _secret = iconfiguration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = iconfiguration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
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

        public string login_Customer(LoginCustomer loginCustomer)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spLoginCustomer", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email_id", loginCustomer.email_id);
                cmd.Parameters.AddWithValue("@passwords", loginCustomer.passwords);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AfterLoginValidate afterLoginValidate = new AfterLoginValidate();

                    AfterLoginValidate afterLoginValidate1 = new AfterLoginValidate();
                    afterLoginValidate1.customer_id = Convert.ToInt32(rdr["customer_id"]);
                    afterLoginValidate1.email_id = rdr["email_id"].ToString();
                    if(afterLoginValidate1.email_id != null) 
                    {
                        sqlConnection.Close();
                        ForgetPasswordMessage forgetPasswordMessage = new ForgetPasswordMessage();
                        string jwtToken = GenerateSecurityToken(afterLoginValidate1.email_id, afterLoginValidate1.customer_id);
                        forgetPasswordMessage.sendData2Queue(jwtToken);
                        return jwtToken;
                    }
                    sqlConnection.Close();
                    return null;
                }
                sqlConnection.Close();
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GenerateSecurityToken(string email, long UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
