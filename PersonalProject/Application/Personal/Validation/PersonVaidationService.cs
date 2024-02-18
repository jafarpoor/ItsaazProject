using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.DTO;
using Common.ErrorMassage;
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
                    return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { ErrorMassageString.DuplicateEmail } };
            }
            catch (Exception)
            {
                return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { ErrorMassageString.CachError } };
            }
         
        }

        public ResultDataModel CheckUniqUser(AddPersonViewModel addPersonViewModel)
        {
            try
            {
                var Result = _context.People.Where(p => p.Firstname == addPersonViewModel.Firstname 
                                                    && p.Lastname == addPersonViewModel.Lastname 
                                                    && p.DateOfBirth == addPersonViewModel.DateOfBirth).FirstOrDefault();
                if (Result == null)
                    return new ResultDataModel()
                    {
                        IsSuccess = true,
                    };
                else
                    return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { ErrorMassageString.DuplicateUser } };
            }
            catch (Exception)
            {
                return new ResultDataModel() { IsSuccess = false, Message = new List<string>() { ErrorMassageString.CachError } };
            }

        }
    }
}
