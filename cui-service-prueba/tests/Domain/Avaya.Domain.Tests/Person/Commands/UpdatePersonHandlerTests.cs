namespace Ibero.Services.Avaya.Domain.Tests.Degree.Commands
{
    using FluentValidation.TestHelper;
    using Ibero.Services.Avaya.Domain.Exceptions;
    using Ibero.Services.Avaya.Domain.Person.Commands.UpdatePerson;
    using Ibero.Services.Avaya.Domain.Tests.Infrastructure;
    using Ibero.Services.Avaya.Persistence;
    using Shouldly;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("QueryCollection")]
    public class UpdateDegreeHandlerTests
    {
        private readonly AvayaDbContext context;
        private readonly UpdatePersonCommandValidator validator;

        public UpdateDegreeHandlerTests(TestFixture fixture)
        {
            context = fixture.Context;
            validator = new UpdatePersonCommandValidator();
        }

        [Fact]
        public async Task Request_ShouldUpdateTest()
        {
            var handler = new UpdatePersonCommand.Handler(context);

            var result = await handler.Handle(new UpdatePersonCommand { Id_Banner = "100059339", Num_Document = "1234567", Nam_Person = "Test Nombre", Last_NamePerson = "Test Apellido" }, CancellationToken.None);

            result.ShouldNotBeNull();
        }

        [Fact]
        public void Validate_Request_ShouldNotHaveError()
        {
            var command = new UpdatePersonCommand { Id_Banner = "100059339" };
            validator.ShouldNotHaveValidationErrorFor(x => x.Id_Banner, command);
        }

        [Fact]
        public void Validate_Request_ShouldHaveError()
        {
            var command = new UpdatePersonCommand { Id_Banner = "" };
            validator.ShouldHaveValidationErrorFor(x => x.Id_Banner, command);
        }

        [Fact]
        public void Request_ShouldThrowUpdateFailureException()
        {
            var sut = new UpdatePersonCommand.Handler(context);
            var Id_Banner = "123";

            Should.Throw<UpdateFailureException>(() => sut.Handle(new UpdatePersonCommand { Id_Banner = Id_Banner }, CancellationToken.None));
        }
    }
}
