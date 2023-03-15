using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.CustomerModels
{
    public class ResetPassword
    {
        [Required]
        public string passwords { get; set; }
        [Required]
        public string confirm_passwords { get; set; }
    }
}
