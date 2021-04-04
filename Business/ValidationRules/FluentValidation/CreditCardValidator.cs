using System;
using System.Collections.Generic;
using System.Text;
using Entites.Concerete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.ValidationYear).GreaterThan(System.DateTime.Now.Year);
            RuleFor(c => c.ValidationMonth).GreaterThan(System.DateTime.Now.Month);
            RuleFor(c => c.ValidationMonth).GreaterThanOrEqualTo(12);
            RuleFor(c => c.CardNumber.ToString().Length).Equals(16);
            RuleFor(c => c.CardHolderName.Length).GreaterThan(2);

        }
    }
}
