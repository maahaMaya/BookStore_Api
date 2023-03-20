using CommonLayer.Models.AddressModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_CustomerAddress_Rl
    {
        public AddCustomerAddress addCustomerAddress(AddCustomerAddress addCustomerAddress);
        public bool deleteCustomerAddress(GetAddressId getAddressId);
    }
}
