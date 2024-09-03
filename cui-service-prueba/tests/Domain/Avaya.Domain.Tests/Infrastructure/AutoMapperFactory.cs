namespace Ibero.Services.Avaya.Domain.Tests.Infrastructure
{
    using AutoMapper;
    using Ibero.Services.Avaya.Domain.Infrastructure.Mapping;

    public class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
