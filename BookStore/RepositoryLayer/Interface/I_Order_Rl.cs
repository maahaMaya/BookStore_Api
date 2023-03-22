using CommonLayer.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface I_Order_Rl
    {
        public CreateOrder placeCustomerOder(CreateOrder createOrder);
    }
}
