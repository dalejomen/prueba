using AutoMapper;
using Ibero.Services.Avaya.Domain.Exceptions;
using Ibero.Services.Avaya.Domain.Uassessment.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Ibero.Services.Avaya.Domain.Uassessment.Queries
{
    public class GetDescripcionEstadoHistoricosQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetDescripcionEstadoHistoricosQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetDescripcionEstadoHistoricosQuery request, CancellationToken cancellationToken)
            {
                var response = new List<DescripcionEstadoHistoricoModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_DESCRIPCIONESTADOHISTORICO", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    DescripcionEstadoHistoricoModel model = new DescripcionEstadoHistoricoModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_estado = sqlReader.GetString(1);
                                    model.nombre_indicador_estado = sqlReader.GetString(2);
                                    model.descripcion_estado_historico = sqlReader.GetString(3);
                                    
                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetDescripcionEstadoHistoricosQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
