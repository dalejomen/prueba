namespace Microsoft.Extensions.DependencyInjection
{
    using AutoMapper;
    using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
    using Ibero.Services.Avaya.Domain.Infrastructure.Mapping;
    using Ibero.Services.Avaya.Domain.Person.Commands.UpdatePerson;
    using Ibero.Services.Avaya.Persistence;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public static class AvayaServiceCollectionExtensions
    {
        public static IServiceCollection AddAvayaService(this IServiceCollection service)
        {
            var sp = service.BuildServiceProvider();
            var configuration = sp.GetService<IConfiguration>();

            service.AddDbContext<IAvayaDbContext, AvayaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AvayaDb")));

            service.AddMediatR(typeof(UpdatePersonCommand.Handler));

            service.AddAutoMapper(typeof(PersonProfile));

            return service;
        }
    }
}
