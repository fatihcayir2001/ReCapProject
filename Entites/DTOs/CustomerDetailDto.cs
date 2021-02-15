using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}
