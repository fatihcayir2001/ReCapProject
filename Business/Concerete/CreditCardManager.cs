using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concerete;

namespace Business.Concerete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<CreditCard>> GetAll()
        {
            var result = _creditCardDal.GetAll();
            return new SuccessDataResult<List<CreditCard>>(result, Messages.OperationSuccessful);
        }
    }
}
