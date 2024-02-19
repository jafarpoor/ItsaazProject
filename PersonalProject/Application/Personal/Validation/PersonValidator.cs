using Common.ErrorMassage;
using Domain.Personal;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Personal.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Firstname).NotEmpty().WithMessage(MassageString.EnterName);
            RuleFor(person => person.Lastname).NotEmpty().WithMessage(MassageString.EnterLastName);
            RuleFor(x => x.Email).EmailAddress().WithMessage(MassageString.EnterValidEmail);
            RuleFor(library => library.PhoneNumber).NotEmpty().Matches(@"^\d{11}$").WithMessage(MassageString.EnterValidPhoneNumber);
        }
    }
}
