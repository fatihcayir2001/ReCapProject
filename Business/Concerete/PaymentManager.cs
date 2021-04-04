using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entites.Concerete;

namespace Business.Concerete
{
    public class PaymentManager : IPaymentService
    {
        public IResult IsPaymentValid(Payment payment)
        {
            if (payment.ValidationYear == FakeCard.ValidationYear &&
                payment.ValidationMonth == FakeCard.ValidationMonth &&
                payment.CVC == FakeCard.CVC &&
                payment.CardHolderName == FakeCard.CardHolderName &&
                payment.CardNumber == FakeCard.CardNumber &&
                payment.Amount <= FakeCard.Balance)
            {
                return new SuccessResult(Messages.PaymentSuccessful);
            }

            return new ErrorResult(Messages.PaymentFailed);
        }
    }
}
