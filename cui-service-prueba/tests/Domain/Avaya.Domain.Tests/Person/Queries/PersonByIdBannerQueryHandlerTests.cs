namespace Ibero.Services.Avaya.Domain.Tests.Person.Queries
{
    using AutoMapper;
    using Ibero.Services.Avaya.Domain.Person.Models;
    using Ibero.Services.Avaya.Domain.Person.Queries;
    using Ibero.Services.Avaya.Domain.Tests.Infrastructure;
    using Ibero.Services.Avaya.Persistence;
    using Shouldly;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("QueryCollection")]
    public class PersonByIdBannerQueryHandlerTests
    {
        private readonly AvayaDbContext context;
        private readonly IMapper mapper;

        public PersonByIdBannerQueryHandlerTests(TestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public async Task PersonByIdBannerTest()
        {
            var TestIdBanner = "100059339";

            var handler = new PersonByIdBannerQuery.Handler(context, mapper);

            var result = await handler.Handle(new PersonByIdBannerQuery { IdBanner = TestIdBanner }, CancellationToken.None);

            result.ShouldBeOfType<List<PersonModel>>();
            result.Count.ShouldBe(1);
        }
    }
}
