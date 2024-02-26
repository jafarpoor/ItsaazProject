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
    public class Put_PersonController
    {
        private Mock<IMapper> _mapper;
        private Mock<IPersonServices> _personServices;
        private const int id = 4;

        public Put_PersonController()
        {
            _mapper = new Mock<IMapper>();
            _personServices = new Mock<IPersonServices>();
        }

        [Fact]
        public async Task Put_PersonController_200Ok()
        {
            // Arrange
            var updatePersonDTO = new EditPersonViewModel
            {
                Id = 4,
                Firstname = "testNameEdit",
                Lastname = "testLastEdit",
                PhoneNumber = "09034882131",
                Email = "testEdit@gmail.com",
                DateOfBirth = DateTime.Now
            };

            var person = new Person
            {
                Id = updatePersonDTO.Id,
                Firstname = updatePersonDTO.Firstname,
                Lastname = updatePersonDTO.Lastname,
                PhoneNumber = updatePersonDTO.PhoneNumber,
                Email = updatePersonDTO.Email,
                DateOfBirth = DateTime.Now
            };

            var responsePersonDTO = new ResponsePersonDTO
            {
                Id = person.Id,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                DateOfBirth = DateTime.Now
            };

            _personServices.Setup(service => service.EditAsync(person).Result).Returns(person);
            _mapper.Setup(mapper => mapper.Map<Person>(It.IsAny<EditPersonViewModel>())).Returns(person);
            _mapper.Setup(mapper => mapper.Map<ResponsePersonDTO>(It.IsAny<Person>())).Returns(responsePersonDTO);

            var controller = new PersonTestController(_mapper.Object, _personServices.Object);

            // Act
            var res = await controller.Put(updatePersonDTO);


            // Assert
            var result = Assert.IsType<OkObjectResult>(res);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async Task Put_PersonController_400BadRequest()
        {
            // Do something that failed the real controller to perform the bad result
            // Arrange
            var updatePersonDTO = new EditPersonViewModel
            {
                Id = id,
                Firstname = "testNameEdit",
                Lastname = "testLastEdit",
                PhoneNumber = "09034882131",
                Email = "testEdit@gmail.com",
                DateOfBirth = DateTime.Now
            };
            var post = new Person
            {
                Id = updatePersonDTO.Id,
                Firstname = updatePersonDTO.Firstname,
                Lastname = updatePersonDTO.Lastname,
                PhoneNumber = updatePersonDTO.PhoneNumber ,
                Email = updatePersonDTO.Email ,
                DateOfBirth= DateTime.Now
            };
            // For instance dont map the object or send null value
            // here without mapping, a null object will pass to the controller 

            //_postServices.Setup(service => service.AddAsync(post).Result).Returns(post);

            var controller = new PersonTestController(_mapper.Object, _personServices.Object);

            // Act
            var res = await controller.Put(updatePersonDTO);


            // Assert
            var result = Assert.IsType<BadRequestResult>(res);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        public void Put_PersonController_Validation()
        {
            // Arrange
            var updatePersonDTO = new UpdatePersonTestDTO
            {
                Id = "FBFF1432-05BC-4686-A888-90B86A70D07C",
                Title = null,
                UserName = "test",
                CreatedAt = DateTime.Now
            };


            // Act
            var validationContext = new ValidationContext(updatePersonDTO);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(updatePersonDTO, validationContext, validationResult, true);

            // Assert
            Assert.False(isValid);
            // The error message should be the same error message that specified in the DTO object which is going to be validated
            Assert.Contains(validationResult, vr => vr.ErrorMessage == "The Title field is required.");
        }
    }
}
