using Entites.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {

        public CarValidator()
        {
            RuleFor(c => c.ModelYear).GreaterThan(2000);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
        }
    }
}
