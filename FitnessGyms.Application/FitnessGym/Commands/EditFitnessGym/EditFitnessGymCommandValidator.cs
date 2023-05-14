using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym.Commands.EditFitnessGym
{
    public class EditFitnessGymCommandValidator : AbstractValidator<EditFitnessGymCommand>
    {
        public EditFitnessGymCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);

        }
    }
}
