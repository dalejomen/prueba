using AutoMapper;
using Ibero.Services.Avaya.Domain.Exceptions;
using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ibero.Services.Avaya.Domain.Adviser.Commands
{
    public class UpdateStateCaseAdviser : IRequest<object>
    {
        public string Documento { get; set; }
        public string Codigo { get; set; }
        public string Apoyo_Tipo { get; set; }
        public string Area_SubArea { get; set; }
        public string Descripcion { get; set; }
        public string CaseId { get; set; }
        public string id { get; set; }

        private DateTime Fecha_Apoyo_Fin = DateTime.Now;

        public class Handler : IRequestHandler<UpdateStateCaseAdviser, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;

            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("Adviser");
            }
            public async Task<object> Handle(UpdateStateCaseAdviser request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";

                var JsonData = JsonConvert.SerializeObject(request).ToString();

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ADVISER_CRM", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@reference", SqlDbType.Int).Value = 4;
                            cmd.Parameters.Add("@JsonData", SqlDbType.VarChar).Value = JsonData;
                            ;

                            await sql.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    response = infoDB;
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(UpdateStateCaseAdviser), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
