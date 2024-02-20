using Application.Interfaces.Personal;
using Application.Personal.DTO;
using EndPointSite.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestPersonProject
{
    public class TestPersonController
    {
        [Fact]
        public void Index_Test()
        {
            var mockRepo = new Mock<IPersonFacade>();
            mockRepo.Setup(repo => repo.GetListPersonService.GetAll())
                      .Returns(GetTestSessions());
            //Arrang
            PersonController home = new(mockRepo.Object);

            //Act
            var result = home.Index();

            //Assert
            Assert.IsType<ViewResult>(result);

        }

        private List<ListPersonViewModel> GetTestSessions()
        {
            return new List<ListPersonViewModel> { };
        }
    }
}
