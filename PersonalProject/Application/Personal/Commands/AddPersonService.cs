using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.DTO;
using Application.Personal.Validation;
using Common.BaseDTO;
using Common.ErrorMassage;
using Domain.Personal;
using FluentValidation.Results;
using System.Diagnostics.Metrics;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Personal.Commands
{
    public class AddPersonService : IAddPersonService
    {
        private readonly IDataBaseContext _context;

        public AddPersonService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDataModel Add(AddPersonViewModel addPersonViewModel)
        {
            try
            {
                var person = new Person
                {
                    Firstname = addPersonViewModel.Firstname,
                    Lastname = addPersonViewModel.Lastname,
                    Email = addPersonViewModel.Email,
                    DateOfBirth = addPersonViewModel.DateOfBirth,
                    PhoneNumber = addPersonViewModel.PhoneNumber,
                };
              _context.People.Add(person);
              _context.SaveChanges();
                return new ResultDataModel
                {
                    IsSuccess = true,
                    Message = new List<string> { ErrorMassageString.SaveMassage }
                };

            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    IsSuccess = false,
                    Message = new List<string> { ErrorMassageString.CachError }
                };
            }
        }
    }
}
