using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concerete
{
    public class Payment
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ValidationMonth { get; set; }
        public string ValidationYear { get; set; }
        public string CVC { get; set; }
        public int Amount { get; set; }
    }
}
