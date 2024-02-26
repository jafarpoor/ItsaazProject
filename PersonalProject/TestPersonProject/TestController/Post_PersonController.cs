using Application.Personal.DTO;
using Application.Personal.ServiceTest;
using Domain.Personal;
using EndPointSite.Controllers;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace TestPersonProject.TestController
{
    public class Person_PersonController
    {
        private Mock<IMapper> _mapper;
        private Mock<IPersonServices> _personServices;

        public Person_PersonController()
        {
            _mapper = new Mock<IMapper>();
            _personServices = new Mock<IPersonServices>();
        }

        [Fact]
        public async Task Person_PersonController_200Ok()
        {
            // Arrange
            var createPersonDTO = new AddPersonViewModel
            {
                Id = 6,
                Firstname = "testName",
                Lastname = "testLast",
                PhoneNumber = "09034882131",
                Email = "test6@gmail.com",
                DateOfBirth = DateTime.Now
            };

            var person = new Person
            {
                Id = createPersonDTO.Id,
                Firstname = createPersonDTO.Firstname,
                Lastname = createPersonDTO.Lastname,
                PhoneNumber = createPersonDTO.PhoneNumber ,
                Email = createPersonDTO.Email,
                 DateOfBirth= DateTime.Now
            };

            var responsePersonDTO = new ResponsePersonDTO
            {
                Id = person.Id,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                PhoneNumber = person.PhoneNumber ,
                Email = person.Email,
                DateOfBirth= DateTime.Now
            };

            _personServices.Setup(service => service.AddAsync(person).Result).Returns(person);
            _mapper.Setup(mapper => mapper.Map<Person>(It.IsAny<AddPersonViewModel>())).Returns(person);
            _mapper.Setup(mapper => mapper.Map<ResponsePersonDTO>(It.IsAny<Person>())).Returns(responsePersonDTO);

            var controller = new PersonTestController(_mapper.Object, _personServices.Object);

            // Act
            var res = await controller.Post(createPersonDTO);


            // Assert
            var result = Assert.IsType<CreatedAtActionResult>(res);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        }

        [Fact]
        public async Task Person_PersonController_400BadRequest()
        {
            // Do something that failed the real controller to perform the bad result
            // Arrange
            var createPersonDTO = new AddPersonViewModel
            {
                Id = 9,
                Firstname = "testName9",
                Lastname = "testLast9",
                PhoneNumber = "09034882131",
                Email = "test9@gmail.com",
                DateOfBirth = DateTime.Now
            };
            var person = new Person
            {
                Id = createPersonDTO.Id,
                Firstname = createPersonDTO.Firstname,
                Lastname = createPersonDTO.Lastname,
                PhoneNumber = createPersonDTO.PhoneNumber ,
                Email = createPersonDTO.Email,
                DateOfBirth = DateTime.Now
            };
            // For instance dont map the object or send null value
            // here without mapping, a null object will pass to the controller 
            _personServices.Setup(service => service.AddAsync(person).Result).Returns(person);

            var controller = new PersonTestController(_mapper.Object, _personServices.Object);

            // Act
            var res = await controller.Post(createPersonDTO);


            // Assert
            var result = Assert.IsType<BadRequestResult>(res);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        public void Person_PersonController_Validation()
        {
            //// Arrange
            //var createPersonDTO = new AddPersonViewModel
            //{
            //    Id = 8,
            //    Firstname = "testName8",
            //    Lastname = "testLast8",
            //    PhoneNumber = "09034882131",
            //    Email = "test8@gmail.com",
            //    DateOfBirth = DateTime.Now
            //};

            // Arrange
            var createPostDTO = new CreatePersonTestDTO
            {
                Id = Guid.NewGuid().ToString(),
                Title = null,
                UserName = "test",
                CreatedAt = DateTime.Now
            };


            // Act
            var validationContext = new ValidationContext(createPostDTO);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(createPostDTO, validationContext, validationResult, true);

            // Assert
            Assert.False(isValid);
            // The error message should be the same error message that specified in the DTO object which is going to be validated
            Assert.Contains(validationResult, vr => vr.ErrorMessage == "The Title field is required.");
        }
    }
}
