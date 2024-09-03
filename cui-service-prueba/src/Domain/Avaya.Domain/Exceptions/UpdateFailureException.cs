namespace Ibero.Services.Avaya.Domain.Exceptions
{
    using System;

    public class UpdateFailureException : Exception
    {
        public UpdateFailureException(string name, object key, string message)
            : base($"Updating of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
