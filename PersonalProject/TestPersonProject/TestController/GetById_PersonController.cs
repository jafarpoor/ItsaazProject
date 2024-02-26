using Application.Personal.DTO;
using Application.Personal.ServiceTest;
using Domain.Personal;
using EndPointSite.Controllers;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestPersonProject.TestController
{
    public class GetById_PersonController
    {
        private Mock<IMapper> _mapper;
        private Mock<IPersonServices> _postServices;

        private const int id = 4;


        public GetById_PersonController()
        {
            _mapper = new Mock<IMapper>();
            _postServices = new Mock<IPersonServices>();
        }

        [Fact]
        public async Task GetById_PersonController_NotEmpty()
        {
            // Arrange
            var data = new PersonDummyData();
            var returnObj = data.GetAllPerson().FirstOrDefault(p => p.Id == id);


            var postResponseDTO = new ResponsePersonDTO
            {
             Id = id,
             Firstname = returnObj.Firstname,
             Lastname= returnObj.Lastname,
             Email = returnObj.Email,
             PhoneNumber = returnObj.PhoneNumber,
             DateOfBirth =System.DateTime.Now            
            };

            _postServices.Setup(service => service.GetByIdAsync(id).Result).Returns(returnObj);
            _mapper.Setup(mapper => mapper.Map<ResponsePersonDTO>(It.IsAny<Person>())).Returns(postResponseDTO);

            var controller = new PersonTestController(_mapper.Object, _postServices.Object);

            // Act
            var res = await controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(res);
            var model = Assert.IsAssignableFrom<ResponsePersonDTO>(okResult.Value);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task GetById_PersonController_204NotFound()
        {
            // Arrange
            var data = new PersonDummyData();

            // Do something that is a cause for not found result - here
            _postServices.Setup(service => service.GetByIdAsync(0).Result).Returns(data.GetAllPerson().FirstOrDefault(p => p.Id == 0));
            _mapper.Setup(mapper => mapper.Map<ResponsePersonDTO>(It.IsAny<Person>()));

            var controller = new PersonTestController(_mapper.Object, _postServices.Object);

            // Act
            // Do something that is a cause for not found result - and here
            var res = await controller.GetById(0);

            // Assert
            var notFoundtResult = Assert.IsType<NotFoundResult>(res);
            Assert.Equal(StatusCodes.Status404NotFound, notFoundtResult.StatusCode);
        }

        [Fact]
        public async Task GetById_PersonController_200Ok()
        {
            // Arrange
            var data = new PersonDummyData();
            _postServices.Setup(service => service.GetByIdAsync(id).Result).Returns(data.GetAllPerson().FirstOrDefault(p => p.Id == id));
            _mapper.Setup(mapper => mapper.Map<ResponsePersonDTO>(It.IsAny<Person>()));

            var controller = new PersonTestController(_mapper.Object, _postServices.Object);

            // Act
            var res = await controller.GetById(id);

            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(res);
            Assert.Equal(StatusCodes.Status200OK, OkResult.StatusCode);
        }
    }
}
