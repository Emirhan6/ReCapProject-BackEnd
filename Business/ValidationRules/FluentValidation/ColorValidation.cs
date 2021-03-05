using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidation :AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(co => co.ColorId).NotEmpty();
            RuleFor(co => co.ColorName).NotEmpty();
            RuleFor(co => co.ColorName).MinimumLength(1);
        }
    }
}
