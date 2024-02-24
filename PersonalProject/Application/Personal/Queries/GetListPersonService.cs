using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.DTO;

namespace Application.Personal.Queries
{
    public class GetListPersonService : IGetListPersonService
    {
        private readonly IDataBaseContext _context;
        public GetListPersonService(IDataBaseContext context)
        {
            _context = context;
        }

        public List<ListPersonViewModel> GetAll()
        {
            try
            {
                List<ListPersonViewModel> Result = _context.People.Select(p => new ListPersonViewModel
                {
                    Id = p.Id,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Email = p.Email,
                    DateOfBirth = p.DateOfBirth,
                    PhoneNumber = p.PhoneNumber,
                }).ToList();
                return Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
