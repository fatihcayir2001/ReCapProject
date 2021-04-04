using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entites.Concerete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult IsPaymentValid(Payment payment);
    }
}
