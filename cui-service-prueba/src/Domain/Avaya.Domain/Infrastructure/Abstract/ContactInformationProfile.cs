namespace Ibero.Services.Utilitary.Domain.Infrastructure.Mapping
{
    using AutoMapper;
    using Ibero.Services.Utilitary.Core.Entities;
    using Ibero.Services.Utilitary.Domain.ContactInformation.Models;

    public class ContactInformationProfile : Profile
    {
        public ContactInformationProfile()
        {
            CreateMap<ContactInformation, ContactInformationModel>();
        }
    }
}
