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
            RuleFor(person => person.Firstname).NotEmpty().WithMessage(ErrorMassageString.EnterName);
            RuleFor(person => person.Lastname).NotEmpty().WithMessage(ErrorMassageString.EnterLastName);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMassageString.EnterValidEmail);
            RuleFor(library => library.PhoneNumber).NotEmpty().Matches(@"^\d{11}$").WithMessage(ErrorMassageString.EnterValidPhoneNumber);
        }
    }
}
