using BusinessLayer.Interface;
using CommonLayer.Models.OrderModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class Order_Bl : I_Order_Bl
    {
        I_Order_Rl i_Order_Rl;
        public Order_Bl(I_Order_Rl i_Order_Rl) 
        {
            this.i_Order_Rl = i_Order_Rl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createOrder"></param>
        /// <returns></returns>
        public CreateOrder placeCustomerOder(CreateOrder createOrder)
        {
            try
            {
                return i_Order_Rl.placeCustomerOder(createOrder);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
