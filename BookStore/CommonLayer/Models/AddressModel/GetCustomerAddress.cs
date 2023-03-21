using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models.AddressModel
{
    public class GetCustomerAddress
    {
        public string fullname { get; set; }
        public int phone_number { get; set; }
        public int address_id { get; set; }
        public int customer_id { get; set; }
        public int address_type_id { get; set; }
        public string customer_address { get; set; }
        public string customer_city { get; set; }
        public string customer_state { get; set; }
    }
}
