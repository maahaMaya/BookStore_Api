using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.CustomerModels
{
    public class RegisterNewCustomer
    {
        [Required]
        public string fullname { get; set; }
        [Required]
        public string email_id { get; set; }
        [Required]
        public string passwords { get; set; }
        [Required]
        public int phone_number { get; set; }
    }
}
