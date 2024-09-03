namespace Ibero.Services.Avaya.Domain.Person.Commands.UpdatePerson
{
    using FluentValidation;

    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Id_Banner).NotEmpty().NotNull();
        }
    }
}
