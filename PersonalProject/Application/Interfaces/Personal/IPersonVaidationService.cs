using Application.Personal.DTO;
using Domain.Personal;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Interfaces.Personal
{
    public interface IPersonVaidationService
    {
        ResultDataModel CheckUniqEmail(string email);
        ResultDataModel CheckUniqUser(Person person);

    }
}
