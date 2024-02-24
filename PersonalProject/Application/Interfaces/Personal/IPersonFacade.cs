using Application.Personal.ServiceTest;

namespace Application.Interfaces.Personal
{
    public interface IPersonFacade
    {
        IAddPersonService AddPersonService { get; }
        IPersonVaidationService PersonVaidationService { get; }
        IGetListPersonService GetListPersonService { get; }
        IDeletePersonService DeletePersonService { get; }
        IEditPersonService EditPersonService { get; }
        IPersonServices PersonServices { get; }
    }
}
