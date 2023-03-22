using CommonLayer.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface I_Order_Bl
    {
        public CreateOrder placeCustomerOder(CreateOrder createOrder);
    }
}
