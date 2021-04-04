using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard,CarProjectContext> , ICreditCardDal
    {


    }
}
