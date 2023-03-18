using CommonLayer.Models.CartModels;
using CommonLayer.Models.CustomerModels;
using CommonLayer.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_CustomerBl
    {
        public IEnumerable<GetAllCustomer> getAllCustomer();
        public IEnumerable<GetAllCustomer> getCustomerById(GetCustomerId getCustomerId);
        public RegisterNewCustomer registerNewCustomer(RegisterNewCustomer registerNewCustomer);
        public string login_Customer(LoginCustomer loginCustomer);

        public bool reset_login_password(ResetPassword resetPassword, string email_id);

        public string forget_login_password(ForgetPassword forgetPassword);
    }
}
