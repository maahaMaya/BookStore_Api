using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_CustomerRl
    {
        public IEnumerable<GetAllCustomer> getAllCustomer();
        public RegisterNewCustomer registerNewCustomer(RegisterNewCustomer registerNewCustomer);
        public string login_Customer(LoginCustomer loginCustomer);
        public string forget_login_password(ForgetPassword forgetPassword);
        public bool reset_login_password(ResetPassword resetPassword, string email_id);
    }
}
