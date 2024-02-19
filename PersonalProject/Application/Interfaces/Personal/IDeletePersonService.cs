using static Common.BaseDTO.ResultViewModel;

namespace Application.Interfaces.Personal
{
    public interface  IDeletePersonService
    {
        ResultDataModel Delete(int Id);
    }
}
