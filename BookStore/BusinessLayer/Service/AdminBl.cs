using BusinessLayer.Interface;
using CommonLayer.Models.AdminModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBl : I_AdminBl
    {
		I_AdminRl i_AdminRl;
		public AdminBl(I_AdminRl i_AdminRl) 
		{
			this.i_AdminRl = i_AdminRl;
		}
        public string login_Admin(LoginAdmin loginAdmin)
        {
			try
			{
				return i_AdminRl.login_Admin(loginAdmin);
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
