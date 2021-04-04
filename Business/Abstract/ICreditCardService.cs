using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entites.Concerete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll();
    }
}
