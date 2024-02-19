using Application.Personal.DTO;
using static Common.BaseDTO.ResultViewModel;

namespace Application.Interfaces.Personal
{
    public interface IEditPersonService
    {
        ResultDataModel Edit(EditPersonViewModel viewModel);
    }
}
