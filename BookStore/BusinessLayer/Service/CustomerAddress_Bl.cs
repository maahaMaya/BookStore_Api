using BusinessLayer.Interface;
using CommonLayer.Models.AddressModel;
using CommonLayer.Models.CartModels;
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
        public bool deleteCustomerAddress(GetAddressId getAddressId)
        {
            try
            {
                return i_CustomerAddress_Rl.deleteCustomerAddress(getAddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetCustomerAddress> getCustomerAddress(GetCustomerId getCustomerId)
        {
            try
            {
                return i_CustomerAddress_Rl.getCustomerAddress(getCustomerId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
