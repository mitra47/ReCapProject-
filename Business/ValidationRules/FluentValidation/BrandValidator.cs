using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("Araç isimleri A ile Başlamalı");
           
            
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
