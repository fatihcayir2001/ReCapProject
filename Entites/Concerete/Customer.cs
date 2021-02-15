using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entites.Concerete
{
    public class Customer:IEntity
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
    }
}
