using CommonLayer.Models.AdminModel;
using CommonLayer.Models.CustomerModels;
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
    public class AdminRl : I_AdminRl
    {
        public readonly string _connectionString;
        private readonly string _secret;
        private readonly string _expDate;
        public AdminRl(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetSection("ConnectionString").GetSection("BookStore").Value;
            _secret = iconfiguration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = iconfiguration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }
        SqlConnection sqlConnection;

        public string login_Admin(LoginAdmin loginAdmin)
        {
            sqlConnection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spLoginAdmin", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email_id", loginAdmin.email_id);
                cmd.Parameters.AddWithValue("@passwords", loginAdmin.passwords);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AfterLoginValidate afterLoginValidate = new AfterLoginValidate();

                    AfterLoginValidate afterLoginValidate1 = new AfterLoginValidate();
                    afterLoginValidate1.customer_id = Convert.ToInt32(rdr["admin_id"]);
                    afterLoginValidate1.email_id = rdr["email_id"].ToString();
                    if (afterLoginValidate1.email_id != null)
                    {
                        sqlConnection.Close();
                        return GenerateSecurityTokenAdmin(afterLoginValidate1.email_id, afterLoginValidate1.customer_id);
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
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public string GenerateSecurityTokenAdmin(string email, long UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, "Admin"),
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
