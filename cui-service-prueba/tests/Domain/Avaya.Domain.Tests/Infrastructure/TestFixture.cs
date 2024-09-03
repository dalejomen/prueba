namespace Ibero.Services.Avaya.Domain.Tests.Infrastructure
{
    using System;
    using AutoMapper;
    using Ibero.Services.Avaya.Persistence;
    using Xunit;

    public class TestFixture : IDisposable
    {
        public AvayaDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public TestFixture()
        {
            Context = AvayaDbContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }
        public void Dispose()
        {
            AvayaDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<TestFixture> { }
}
