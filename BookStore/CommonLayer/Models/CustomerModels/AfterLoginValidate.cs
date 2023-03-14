using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.CustomerModels
{
    public class AfterLoginValidate
    {
        [Required]
        public int customer_id { get; set; }
        [Required]
        public string email_id { get; set; }
    }
}
