using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImagerValidator: AbstractValidator<CarImage>
    {
        public CarImagerValidator()
        {
            RuleFor(c => c.CarImageID).GreaterThan(5);
        }
    }
}
