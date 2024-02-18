namespace Application.Interfaces.Personal
{
    public interface IPersonFacade
    {
        IAddPersonService AddPersonService { get; }
        IPersonVaidationService PersonVaidationService { get; }
        IGetListPersonService GetListPersonService { get; }
    }
}
