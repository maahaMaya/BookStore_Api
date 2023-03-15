using CommonLayer.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_AdminRl
    {
        public string login_Admin(LoginAdmin loginAdmin);
    }
}
