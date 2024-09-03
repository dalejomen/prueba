namespace Ibero.Services.Avaya.API.V1.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator ?? (mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
