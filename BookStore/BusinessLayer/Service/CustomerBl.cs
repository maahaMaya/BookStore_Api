using BusinessLayer.Interface;
using CommonLayer.Models.CartModels;
using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.UserModels;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CustomerBl : I_CustomerBl
    {
		I_CustomerRl i_CustomerRl;
		public CustomerBl(I_CustomerRl i_CustomerRl) 
		{
			this.i_CustomerRl = i_CustomerRl;
		}

        public IEnumerable<GetAllCustomer> getAllCustomer()
        {
			try
			{
				return i_CustomerRl.getAllCustomer();
			}
			catch (Exception)
			{

				throw;
			}
        }

        public IEnumerable<GetAllCustomer> getCustomerById(GetCustomerId getCustomerId)
		{
			try
			{
				return i_CustomerRl.getCustomerById(getCustomerId);
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
				return i_CustomerRl.registerNewCustomer(registerNewCustomer);
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
                return i_CustomerRl.login_Customer(loginCustomer);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool reset_login_password(ResetPassword resetPassword, string email_id)
        {
			try
			{
				return i_CustomerRl.reset_login_password(resetPassword, email_id);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public string forget_login_password(ForgetPassword forgetPassword)
		{
			try
			{
				return i_CustomerRl.forget_login_password(forgetPassword);
			}
			catch (Exception)
			{

				throw;
			}
		}

    }
}
