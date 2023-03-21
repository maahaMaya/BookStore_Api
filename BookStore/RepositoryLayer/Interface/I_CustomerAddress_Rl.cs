using CommonLayer.Models.AddressModel;
using CommonLayer.Models.CartModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_CustomerAddress_Rl
    {
        public AddCustomerAddress addCustomerAddress(AddCustomerAddress addCustomerAddress);
        public bool deleteCustomerAddress(GetAddressId getAddressId);
        public IEnumerable<GetCustomerAddress> getCustomerAddress(GetCustomerId getCustomerId);
    }
}
