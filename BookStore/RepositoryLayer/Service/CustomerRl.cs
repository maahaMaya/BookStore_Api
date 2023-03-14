using CommonLayer.Models.UserModels;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CustomerRl : I_CustomerRl
    {
        private readonly IConfiguration iconfiguration;
        public CustomerRl(IConfiguration iconfiguration) 
        { 
            this.iconfiguration = iconfiguration;
        }
    }
}
