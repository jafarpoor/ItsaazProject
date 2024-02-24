using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.Commands;
using Application.Personal.Queries;
using Application.Personal.ServiceTest;
using Application.Personal.Validation;

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


        private IPersonVaidationService _personVaidationService;
        public IPersonVaidationService PersonVaidationService
        {
            get
            {
                return _personVaidationService = _personVaidationService ?? new PersonVaidationService(_context);
            }
        }

        private IGetListPersonService _getListPersonService;
        public IGetListPersonService GetListPersonService
        {
            get
            {
                return _getListPersonService = _getListPersonService ?? new GetListPersonService(_context);
            }
        }

        private IDeletePersonService _deletePersonService;
        public IDeletePersonService DeletePersonService
        {
            get
            {
                return _deletePersonService = _deletePersonService ?? new DeletePersonService(_context);
            }
        }

        private IEditPersonService _editPersonService;
        public IEditPersonService EditPersonService
        {
            get
            {
                return _editPersonService = _editPersonService ?? new EditPersonService(_context);
            }
        }
        private IPersonServices _personServices;
        public IPersonServices PersonServices
        {
            get
            {
                return _personServices = _personServices ?? new PersonServices(_context);
            }
        }
    }
}
