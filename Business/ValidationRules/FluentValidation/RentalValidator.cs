using Entites.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        RentalValidator()
        {
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate);
            RuleFor(r => r.CarId).NotNull();
        }
    }
}
