using Domain.Personal;
using Microsoft.Extensions.Hosting;

namespace TestPersonProject
{
    public class PersonDummyData
    {
        public PersonDummyData()
        {
        }

        public IEnumerable<Person> GetAllPost()
        {
            var posts = new List<Person>();
            posts.Add(new Person { Id = 1, Firstname = "test1", Lastname = "test1", DateOfBirth = DateTime.Now ,Email="teat1@gmail.com" ,PhoneNumber="09034882131" });
            posts.Add(new Person { Id = 2, Firstname = "test2", Lastname = "test2", DateOfBirth = DateTime.Now , Email = "teat2@gmail.com" , PhoneNumber = "09034882132" });
            posts.Add(new Person { Id = 3, Firstname = "test3", Lastname = "test3", DateOfBirth = DateTime.Now , Email = "teat3@gmail.com", PhoneNumber = "09034882133" });
            posts.Add(new Person { Id = 4, Firstname = "test4", Lastname = "test4", DateOfBirth = DateTime.Now , Email = "teat4@gmail.com" , PhoneNumber = "09034882134" });
            posts.Add(new Person { Id = 5, Firstname = "test5", Lastname = "test5", DateOfBirth = DateTime.Now , Email = "teat5@gmail.com" , PhoneNumber = "09034882135" });
            return posts;
        }
    }
}
