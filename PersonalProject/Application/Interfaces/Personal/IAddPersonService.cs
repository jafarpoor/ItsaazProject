using Application.Personal.DTO;
using Common.BaseDTO;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Interfaces.Personal
{
    public interface IAddPersonService
    {
        ResultDataModel Add(AddPersonViewModel addPersonViewModel);
    }
}
