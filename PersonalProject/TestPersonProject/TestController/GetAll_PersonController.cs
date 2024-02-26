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
    public class GetAll_PersonController
    {
        private Mock<IMapper> _mapper;
        private Mock<IPersonServices> _postServices;
        public GetAll_PersonController()
        {
            _mapper = new Mock<IMapper>();
            _postServices = new Mock<IPersonServices>();
        }

        [Fact]
        public async Task GetAll_PersonController_NotEmpty()
        {
            // Arrange
            var data = new PersonDummyData();
            _postServices.Setup(service => service.GetAllAsync().Result).Returns(data.GetAllPerson);
            _mapper.Setup(mapper => mapper.Map<IEnumerable<ResponsePersonDTO>>(It.IsAny<IEnumerable<Person>>()));

            var controller = new PersonTestController(_mapper.Object, _postServices.Object);

            // Act
            var res = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(res);
            var model = Assert.IsAssignableFrom<IEnumerable<ResponsePersonDTO>>(okResult.Value);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task GetAll_PersonController_204NoContent()
        {
            // Arrange
            var data = new PersonDummyData();
            _postServices.Setup(service => service.GetAllAsync().Result).Returns(data.GetAllPerson().Where(p => p.Id == 0).ToList());
            _mapper.Setup(mapper => mapper.Map<IEnumerable<ResponsePersonDTO>>(It.IsAny<IEnumerable<Person>>()));

            var controller = new PersonTestController(_mapper.Object, _postServices.Object);

            // Act
            var res = await controller.Get();

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(res);
            Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_PersonController_200Ok()
        {
            // Arrange
            var data = new PersonDummyData();
            _postServices.Setup(service => service.GetAllAsync().Result).Returns(data.GetAllPerson);
            _mapper.Setup(mapper => mapper.Map<IEnumerable<ResponsePersonDTO>>(It.IsAny<IEnumerable<Person>>()));

            var controller = new PersonTestController(_mapper.Object, _postServices.Object);

            // Act
            var res = await controller.Get();

            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(res);
            Assert.Equal(StatusCodes.Status200OK, OkResult.StatusCode);
        }
    }
}
