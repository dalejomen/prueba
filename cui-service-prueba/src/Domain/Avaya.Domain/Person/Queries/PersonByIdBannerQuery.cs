namespace Ibero.Services.Avaya.Domain.Person.Queries
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Ibero.Services.Avaya.Domain.Exceptions;
    using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
    using Ibero.Services.Avaya.Domain.Person.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class PersonByIdBannerQuery : IRequest<IList<PersonModel>>
    {
        public string IdBanner { get; set; }

        public class Handler : IRequestHandler<PersonByIdBannerQuery, IList<PersonModel>>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;

            public Handler(IAvayaDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<IList<PersonModel>> Handle(PersonByIdBannerQuery request, CancellationToken cancellationToken)
            {
                var validation = context.Person.Any(e => e.Id_Banner == request.IdBanner);

                if (!validation)
                {
                    throw new NotFoundException(nameof(Person), request.IdBanner);
                }

                return await context.Person
                    .Where(e => e.Id_Banner == request.IdBanner)
                    .ProjectTo<PersonModel>(mapper.ConfigurationProvider)
                    .OrderBy(dt => dt.Id_Banner)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
