using Application.Personal.DTO;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Interfaces.Personal
{
    public interface IPersonVaidationService
    {
        ResultDataModel CheckUniqEmail(string email);
        ResultDataModel CheckUniqUser(AddPersonViewModel addPersonViewModel);
    }
}
