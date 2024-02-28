using Application.Personal.DTO;
using Domain.Personal;
using Mapster;

namespace Application.Personal.Mapping
{
    public class PersonMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddPersonViewModel, Person>()
            .Map(d => d.Id, src => src.Id)
            .Map(d => d.Firstname, src => src.Firstname)
            .Map(d => d.Lastname, src => src.Lastname)
            .Map(d => d.PhoneNumber, src => src.PhoneNumber)
            .Map(d => d.DateOfBirth, src => src.DateOfBirth)
            .Map(d => d.Email, src => src.Email);

        config.NewConfig<Person, ListPersonViewModel>()
             .Map(d => d.Id, src => src.Id)
            .Map(d => d.Firstname, src => src.Firstname)
            .Map(d => d.Lastname, src => src.Lastname)
            .Map(d => d.PhoneNumber, src => src.PhoneNumber)
            .Map(d => d.DateOfBirth, src => src.DateOfBirth)
            .Map(d => d.Email, src => src.Email);

            config.NewConfig<EditPersonViewModel, Person>()
             .Map(d => d.Id, src => src.Id)
            .Map(d => d.Firstname, src => src.Firstname)
            .Map(d => d.Lastname, src => src.Lastname)
            .Map(d => d.PhoneNumber, src => src.PhoneNumber)
            .Map(d => d.DateOfBirth, src => src.DateOfBirth)
            .Map(d => d.Email, src => src.Email);


            config.NewConfig<Person, ResponsePersonDTO>()
                       .Map(d => d.Id, src => src.Id)
                      .Map(d => d.Firstname, src => src.Firstname)
                      .Map(d => d.Lastname, src => src.Lastname)
                      .Map(d => d.PhoneNumber, src => src.PhoneNumber)
                      .Map(d => d.DateOfBirth, src => src.DateOfBirth)
                      .Map(d => d.Email, src => src.Email);
        }
    }
}
