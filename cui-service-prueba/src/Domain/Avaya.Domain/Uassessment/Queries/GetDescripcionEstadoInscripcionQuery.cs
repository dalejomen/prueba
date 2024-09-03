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
    public class GetDescripcionEstadoInscripcionQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetDescripcionEstadoInscripcionQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetDescripcionEstadoInscripcionQuery request, CancellationToken cancellationToken)
            {
                var response = new List<DescripcionEstadoInscripcionModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_DESCRIPCIONESESTADOINSCRIPCION", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    DescripcionEstadoInscripcionModel model = new DescripcionEstadoInscripcionModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_estado_inscripcion = sqlReader.GetString(1);
                                    model.codigo_estado_inscripcion = sqlReader.GetString(2);
                                    model.nombre_estado_inscripcion = sqlReader.GetString(3);
                                    model.descripcion_estado_inscripcion = sqlReader.GetString(4);
                                    model.indicador_aprobado = sqlReader.GetString(5);
                                    model.numero_prioridad = sqlReader.GetString(6);
                                   
                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetDescripcionEstadoInscripcionQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
