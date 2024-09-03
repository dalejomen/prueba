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
    public class GetEstudianteSeccionQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetEstudianteSeccionQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetEstudianteSeccionQuery request, CancellationToken cancellationToken)
            {
                var response = new List<EstudianteSeccionModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ESTUDIANTESECCION", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    EstudianteSeccionModel model = new EstudianteSeccionModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_periodo_academico = sqlReader.GetString(1);
                                    model.id_seccion = sqlReader.GetString(2);
                                    model.codigo_grupo = sqlReader.GetString(3);
                                    model.id_estudiante = sqlReader.GetString(4);
                                    model.id_plan_estudio = sqlReader.GetString(5);
                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetEstudianteSeccionQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
