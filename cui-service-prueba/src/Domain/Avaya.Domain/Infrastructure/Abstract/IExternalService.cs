namespace Ibero.Services.Avaya.Domain.Infrastructure.Abstract
{
    using Ibero.Services.Avaya.Core.Models;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Text;
    

    public interface IExternalService
    {

        Task<Transaction> POSTExternalService
            (
               object registrationForm,
               string registrationUrl
            );

    }
}
