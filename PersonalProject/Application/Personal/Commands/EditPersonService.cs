using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.DTO;
using Common.ErrorMassage;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Personal.Commands
{
    public class EditPersonService : IEditPersonService
    {
        private readonly IDataBaseContext _context;

        public EditPersonService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDataModel Edit(EditPersonViewModel viewModel)
        {
            try
            {
                var Result = _context.People.Where(p => p.Id == viewModel.Id).SingleOrDefault();
                if (Result == null)
                    return new ResultDataModel
                    {
                        IsSuccess = false,
                        Message = new List<string>() { MassageString.NotFund }
                        
                    };
                else
                {
                    Result.Firstname = viewModel.Firstname;
                    Result.Lastname = viewModel.Lastname;   
                    Result.Email = viewModel.Email;
                    Result.PhoneNumber = viewModel.PhoneNumber;
                    Result.DateOfBirth = viewModel.DateOfBirth;

                    _context.People.Update(Result);
                    _context.SaveChanges();

                    return new ResultDataModel
                    {
                        IsSuccess = true,
                        Message = new List<string> { MassageString.SaveMassage },
                    };
                }
                 
            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    IsSuccess = false,
                    Message = new List<string> { MassageString.CachError }
                };
            }
        }
    }
}
