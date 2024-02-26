using Application.Personal.ServiceTest;
using EndPointSite.Controllers;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestPersonProject.TestController
{
    public class Delete_PersonController
    {
        private Mock<IMapper> _mapper;
        private Mock<IPersonServices> _personServices;

        private const int id = 4;

        public Delete_PersonController()
        {
            _mapper = new Mock<IMapper>();
            _personServices = new Mock<IPersonServices>();
        }

        [Fact]
        public async Task Delete_PersonController_200Ok()
        {
            // Arrange
            var data = new PersonDummyData();
            var returnObj = data.GetAllPerson().FirstOrDefault(p => p.Id == id);

            _personServices.Setup(service => service.DeleteAsync(id).Result).Returns(true);

            var controller = new PersonTestController(_mapper.Object, _personServices.Object);

            // Act
            var res = await controller.Delete(id);

            // Assert
            var okResult = Assert.IsType<OkResult>(res);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Delete_PersonController_400BadRequest()
        {
            // Arrange
            var data = new PersonDummyData();
            var returnObj = data.GetAllPerson().FirstOrDefault(p => p.Id == 0);

            _personServices.Setup(service => service.DeleteAsync(0).Result).Returns(false);

            var controller = new PersonTestController(_mapper.Object, _personServices.Object);

            // Act
            var res = await controller.Delete(0);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(res);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
        }
    }
}
