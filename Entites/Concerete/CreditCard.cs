using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entites.Concerete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public long CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public int ValidationMonth { get; set; }
        public int ValidationYear { get; set; }
        public int CVC { get; set; }

    }
}
