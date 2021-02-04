using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concerete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
