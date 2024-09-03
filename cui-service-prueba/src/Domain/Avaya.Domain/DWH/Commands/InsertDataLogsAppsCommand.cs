namespace Ibero.Services.Avaya.Domain.DWH.Commands
{
    using AutoMapper;
    using Ibero.Services.Avaya.Core.Models;
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

    public class InsertDataLogsAppsCommand : IRequest<object>
    {
        public string Fuente { get; set; }
        public string Pagina { get; set; }
        public string Accion { get; set; }
        public int Sesion { get; set; }

        public class Handler : IRequestHandler<InsertDataLogsAppsCommand, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;
            private int Reference;

            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("DWHIbero");
            }

            public async Task<object> Handle(InsertDataLogsAppsCommand request, CancellationToken cancellationToken)
            {
                var response = new object();
                try
                {
                    var JsonData = JsonConvert.SerializeObject(request).ToString();
                    Reference = 0;

                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("ADD_SP_LOGS_APLICATIVOS", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.Int).Value = Reference;
                            cmd.Parameters.Add("@JsonData", SqlDbType.VarChar).Value = JsonData;
                            
                            await sql.OpenAsync();
                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    response += sqlReader[0].ToString();
                                }
                            }
                            
                            response += "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(InsertDataLogsAppsCommand), ex.Source, ex.Message);
                }
                return response;
            }
        }
    }
}
