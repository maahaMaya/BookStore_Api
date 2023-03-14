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
        public RegisterNewCustomer registerNewCustomer(RegisterNewCustomer registerNewCustomer);
        public string login_Customer(LoginCustomer loginCustomer);
    }
}
