using BusinessLayer.Interface;
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
    }
}
