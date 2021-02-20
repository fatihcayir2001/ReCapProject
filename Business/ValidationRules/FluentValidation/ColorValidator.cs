using Entites.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        ColorValidator()
        {
            RuleFor(r => r.ColorName.Length).GreaterThan(10);
        }
    }
}
