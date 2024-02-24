using Application.Personal.ServiceTest;
using Domain.Personal;
using TestPersonProject.MockDbContext;

namespace TestPersonProject.Service
{
    public class TestPersonService
    {
        public MockDbContextFactory contextFactory;

        public TestPersonService()
        {
            contextFactory = new MockDbContextFactory();
        }

        [Fact]
        public async Task Add_PostService_Success()
        {
            // Arrange
            var person = new Person
            {
                Id = 4,
                Firstname = "testNew",
                Lastname = "testNew",
                DateOfBirth = DateTime.Now,
                Email = "faezehjafarpour75@gmail.com",
                PhoneNumber = "1234567890",
            };

            var postService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.AddAsync(person);

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public async Task Add_PostService_Failure()
        {

            // Arrange
            var postService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.AddAsync(null);

            // Assert
            Assert.Null(res);
        }

        [Fact]
        public async Task Edit_PostService_Success()
        {
            int id = 4;
            // Arrange
            var person = new Person
            {
                Id = id,
                Firstname = "testNew",
                Lastname = "testNew",
                DateOfBirth = DateTime.Now,
                Email = "faezehjafarpour75@gmail.com",
                PhoneNumber = "1234567890",
            };

            var personService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await personService.EditAsync(person);

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public async Task Edit_PostService_Failure()
        {
            // Arrange
            var person = new Person();
            var personServices = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await personServices.EditAsync(person);

            // Assert
            Assert.Null(res.Id);
        }

        [Fact]
        public async Task Delete_PostService_Success()
        {
            int id = 4;
            // Arrange
            var personService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await personService.DeleteAsync(id);

            // Assert
            Assert.True(res);
        }

        [Fact]
        public async Task Delete_PostService_Failure()
        {
            // Arrange
            var personService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await personService.DeleteAsync(0);

            // Assert
            Assert.False(res);
        }

        [Fact]
        public async Task GetById_PostService_Success()
        {


            int id = 4;
            // Arrange
            var postService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.GetByIdAsync(id);

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public async Task GetById_PostService_Failure()
        {
            // Arrange
            var postService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.GetByIdAsync(0);

            // Assert
            Assert.Null(res);
        }

        [Fact]
        public async Task GetAll_PostService_Success()
        {
            // Arrange
            var postService = new PersonServices(contextFactory.DbContextFactory());
            // Act
            var res = await postService.GetAllAsync();

            // Assert
            Assert.NotNull(res);
        }
    }
}
