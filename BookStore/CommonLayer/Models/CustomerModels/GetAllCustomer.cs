using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.UserModels
{
    public class GetAllCustomer
    {
        public int customer_id { get; set; }
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
