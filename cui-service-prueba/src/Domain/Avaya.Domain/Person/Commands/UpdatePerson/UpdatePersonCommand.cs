namespace Ibero.Services.Avaya.Domain.Person.Commands.UpdatePerson
{
    using Ibero.Services.Avaya.Domain.Exceptions;
    using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdatePersonCommand : IRequest
    {
        public string Id_Banner { get; set; }
        public string Num_Document { get; set; }
        public string Nam_Person { get; set; }
        public string Last_NamePerson { get; set; }

        public class Handler : IRequestHandler<UpdatePersonCommand, Unit>
        {
            private readonly IAvayaDbContext context;

            public Handler(IAvayaDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
            {
                var hasDegree = context.Ibet_Person.Any(p => p.Id_Banner == request.Id_Banner);
                if (!hasDegree)
                {
                    throw new UpdateFailureException(nameof(Person), request.Id_Banner, "Person not found, could not update.");
                }

                var entity = context.Ibet_Person.Where(d => d.Id_Banner == request.Id_Banner).First();
                entity.Num_Document = request.Num_Document;
                entity.Nam_Person = request.Nam_Person;
                entity.Last_NamePerson = request.Last_NamePerson;

                context.Ibet_Person.Update(entity);
                await context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
