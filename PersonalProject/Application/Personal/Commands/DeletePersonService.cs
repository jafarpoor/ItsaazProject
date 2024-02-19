using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Common.ErrorMassage;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Personal.Commands
{
    public class DeletePersonService : IDeletePersonService
    {
        private readonly IDataBaseContext _context;
        public DeletePersonService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDataModel Delete(int Id)
        {
            try
            {
                var Result = _context.People.Where(p => p.Id == Id).SingleOrDefault();
                if (Result == null)
                    return new ResultDataModel
                    {
                        IsSuccess = false,
                        Message = new List<string>() { MassageString.NotFund }
                    };
                else
                {
                    _context.People.Remove(Result);
                    _context.SaveChanges();

                    return new ResultDataModel
                    {
                        IsSuccess = true,
                        Message = new List<string>() { MassageString.SaveMassage }
                    };
                }
                
            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    IsSuccess = false,
                    Message = new List<string>() { MassageString.CachError }
                };
            }
        }
    }
}
