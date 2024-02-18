using Application.Interfaces.Contexts;
using Domain.Personal;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Person>()
                         .HasIndex(p => new { p.Firstname, p.Lastname, p.DateOfBirth }).IsUnique(true);

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                                   .Where(p => p.State == EntityState.Added);

            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType != null)
                {
                    var inserted = entityType.FindProperty("InsertTime");

                    if (item.State == EntityState.Added && inserted != null)
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();

        }
    }
}
