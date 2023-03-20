using CommonLayer.Models.AddressModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_CustomerAddress_Bl
    {
        public AddCustomerAddress addCustomerAddress(AddCustomerAddress addCustomerAddress);
    }
}
