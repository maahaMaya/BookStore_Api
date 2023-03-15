using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.CustomerModels
{
    public class ForgetPassword
    {
        [Required]
        public string email_id { get; set; }
    }
}
