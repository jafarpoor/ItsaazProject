using Application.Interfaces.Contexts;
using Domain.Personal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Persistence.Contexts;
using System;

namespace TestPersonProject.MockDbContext
{
    public class MockDbContextFactory
    {
        public IDataBaseContext DbContextFactory()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>().UseInMemoryDatabase("InMem").Options;

            var context = new DataBaseContext(options);
            context.Database.EnsureCreated();
            context.AddRange(
            new Person { Id = 1, Firstname = "test11", Lastname = "test11", DateOfBirth = DateTime.Now, Email = "teat1@gmail.com", PhoneNumber = "09034882131" },
           new Person { Id = 2, Firstname = "test2", Lastname = "test2", DateOfBirth = DateTime.Now, Email = "teat2@gmail.com", PhoneNumber = "09034882132" },
            new Person { Id = 3, Firstname = "test3", Lastname = "test3", DateOfBirth = DateTime.Now, Email = "teat3@gmail.com", PhoneNumber = "09034882133" },
            new Person { Id = 4, Firstname = "test4", Lastname = "test4", DateOfBirth = DateTime.Now, Email = "teat4gmail.com", PhoneNumber = "09034882134" },
            new Person { Id = 5, Firstname = "test5", Lastname = "test5", DateOfBirth = DateTime.Now, Email = "teat5@gmail.com", PhoneNumber = "09034882135" }
             );
            context.SaveChanges();
            return context;
        }
    }
}
