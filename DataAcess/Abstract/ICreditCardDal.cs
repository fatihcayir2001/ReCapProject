using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entites.Concerete;

namespace DataAccess.Abstract
{
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {
    }
}
