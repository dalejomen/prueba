using Ibero.Services.Avaya.Domain.Exceptions;
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

namespace Ibero.Services.Avaya.Domain.FinancieraDwh.Queries
{
    public class InfoAcadStuCreditQuery : IRequest<object>
    {
        public string id_banner { get; set; }

        public string codProgram { get; set; }
        public class Handler : IRequestHandler<InfoAcadStuCreditQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("Banner");
            }
            public async Task<object> Handle(InfoAcadStuCreditQuery request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_NEGOZIA_INFO_ESTUDIANTE_ACAD", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Id_Banner", SqlDbType.VarChar).Value = request.id_banner;
                            cmd.Parameters.Add("@Cod_Programa", SqlDbType.VarChar).Value = request.codProgram;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    infoDB = sqlReader[0].ToString();
                                }
                            }
                        }
                    }
                    response = infoDB;
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(InfoAcadStuCreditQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }

    }
}
