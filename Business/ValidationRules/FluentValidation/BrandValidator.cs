using Entites.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        BrandValidator()
        {
            RuleFor(b => b.BrandName.Length).GreaterThan(0);
        }
    }
}
