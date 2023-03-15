using CommonLayer.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_AdminBl
    {
        public string login_Admin(LoginAdmin loginAdmin);
    }
}
