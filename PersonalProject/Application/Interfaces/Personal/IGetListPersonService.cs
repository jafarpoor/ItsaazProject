using Application.Personal.DTO;

namespace Application.Interfaces.Personal
{
    public interface IGetListPersonService
    {
        List<ListPersonViewModel> GetAll();
    }
}
