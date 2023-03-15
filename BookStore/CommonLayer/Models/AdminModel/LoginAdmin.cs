using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.AdminModel
{
    public class LoginAdmin
    {
        [Required]
        public string email_id { get; set; }
        [Required]
        public string passwords { get; set; }
    }
}
