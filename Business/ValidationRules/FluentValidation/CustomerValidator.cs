﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cu => cu.CustomerId).NotEmpty();
            RuleFor(cu => cu.CompanyName).NotEmpty();
            RuleFor(cu => cu.UserId).NotEmpty();
        }
    }
}