using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concerete
{
    public class Customer:User
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
    }
}
