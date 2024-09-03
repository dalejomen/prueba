namespace Ibero.Services.Avaya.API.V1.Controllers
{
    using Ibero.Services.Avaya.Core.Models;
    using Ibero.Services.Avaya.Domain.ZohoCrmDwh.Commands;
    using Ibero.Services.Avaya.Domain.ZohoCrmDwh.Queries;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class PruebaController : BaseController
    {

        [HttpGet("Entidades")]
        public async Task<ActionResult<IEnumerable<object>>> Entidades([FromRoute] EntidadesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /*
        [HttpPost("NewAndUpdateTbl_Clientes")]
        public async Task<ActionResult<Response>> NewAndUpdateTbl_ClientesAsync([FromBody] NewZohoTbl_ClientesQuery query)
        {
            try
            {
                var status = Ok(await Mediator.Send(query));

                var response = new Response
                {
                    Title = status.Value.ToString(),
                    Message = "Success",
                    Status = status.StatusCode.ToString()
                };



                return response;
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    Title = ex.Source,
                    Message = ex.Message,
                    Status = StatusCodes.Status400BadRequest.ToString()
                };

                return response;
            }
        }*/
    }
}