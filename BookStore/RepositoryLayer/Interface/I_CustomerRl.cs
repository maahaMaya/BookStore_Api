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
    }
}
