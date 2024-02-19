using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.DTO;
using Common.ErrorMassage;
using Domain.Personal;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Personal.Validation
{
    public class PersonVaidationService : IPersonVaidationService
    {

        private readonly IDataBaseContext _context;

        public PersonVaidationService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDataModel CheckUniqEmail(string email)
        {
            try
            {
                var Result = _context.People.Where(p => p.Email == email).FirstOrDefault();
                if (Result == null)
                    return new ResultDataModel()
                    {
                        IsSuccess = true,
                    };
                else
                    return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { MassageString.DuplicateEmail } };
            }
            catch (Exception)
            {
                return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { MassageString.CachError } };
            }
         
        }

        public ResultDataModel CheckUniqUser(Person person)
        {
            try
            {
                var Result = _context.People.Where(p => p.Firstname == person.Firstname 
                                                    && p.Lastname == person.Lastname 
                                                    && p.DateOfBirth == person.DateOfBirth).FirstOrDefault();
                if (Result == null)
                    return new ResultDataModel()
                    {
                        IsSuccess = true,
                    };
                else
                    return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { MassageString.DuplicateUser } };
            }
            catch (Exception)
            {
                return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { MassageString.CachError } };
            }

        }
    }

}
