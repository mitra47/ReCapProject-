using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarImagesValidator : AbstractValidator<CarImage>
    {
        public CarImagesValidator()
        {

            RuleFor(p => p.CarId).NotNull();
            



        }
    }
}
