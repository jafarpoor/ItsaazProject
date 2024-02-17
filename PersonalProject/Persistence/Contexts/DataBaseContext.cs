using Application.Interfaces.Contexts;
using Domain.Personal;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext 
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
