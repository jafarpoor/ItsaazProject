using Domain.Personal;

namespace Application.Personal.ServiceTest
{
    public interface IPersonServices
    {
        Task<Person> AddAsync(Person post);
        Task<Person> EditAsync(Person post);
        Task<bool> DeleteAsync(int id);
        Task<Person> GetByIdAsync(int id);
        Task<List<Person>> GetAllAsync();
    }
}
