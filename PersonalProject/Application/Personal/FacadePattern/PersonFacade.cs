using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.Commands;

namespace Application.Personal.FacadePattern
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IDataBaseContext _context;
        public PersonFacade(IDataBaseContext context)
        {
            _context = context;
        }

        private IAddPersonService _addPersonService;
        public IAddPersonService AddPersonService
        {
            get
            {
                return _addPersonService = _addPersonService ?? new AddPersonService(_context);

            }
        }
    }
}
