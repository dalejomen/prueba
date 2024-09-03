namespace Ibero.Services.Avaya.Domain.Infrastructure.Mapping
{
    using AutoMapper;
    using Ibero.Services.Avaya.Core.Entities;
    using Ibero.Services.Avaya.Domain.Person.Models;

    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonModel>();
        }
    }
}
