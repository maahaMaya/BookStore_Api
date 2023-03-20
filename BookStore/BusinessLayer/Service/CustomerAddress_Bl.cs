using BusinessLayer.Interface;
using CommonLayer.Models.AddressModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CustomerAddress_Bl : I_CustomerAddress_Bl
    {
        I_CustomerAddress_Rl i_CustomerAddress_Rl;
        public CustomerAddress_Bl(I_CustomerAddress_Rl i_CustomerAddress_Rl) 
        {
            this.i_CustomerAddress_Rl = i_CustomerAddress_Rl;
        }

        public AddCustomerAddress addCustomerAddress(AddCustomerAddress addCustomerAddress)
        {
            try
            {
                return i_CustomerAddress_Rl.addCustomerAddress(addCustomerAddress);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
