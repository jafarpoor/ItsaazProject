using Application.Interfaces.Contexts;
using Domain.Personal;
using Microsoft.EntityFrameworkCore;

namespace Application.Personal.ServiceTest
{
    public class PersonServices : IPersonServices
    {
        private readonly IDataBaseContext _dbContext;

        public PersonServices(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Person> AddAsync(Person person)
        {
            if (person is not null)
            {
                await _dbContext.People.AddAsync(person);
                await _dbContext.SaveChangesAsync();
            }
            return person;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await GetPost(id);
            if (post is not null)
            {
                _dbContext.People.Remove(post);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Person> EditAsync(Person person)
        {
            var persontObj = await GetPost(person.Id);
            if (persontObj is not null)
            {
                persontObj.Firstname = person.Firstname;
                persontObj.Lastname = person.Lastname;
                persontObj.PhoneNumber = person.PhoneNumber;
                person.Email = person.Email;
                person.DateOfBirth = person.DateOfBirth;
                await _dbContext.SaveChangesAsync();
            }
            return persontObj;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbContext.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await GetPost(id);
        }
        private async Task<Person> GetPost(int id)
        {
            return await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
