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
    public class GetSeccionComponentesEvaluacionQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetSeccionComponentesEvaluacionQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetSeccionComponentesEvaluacionQuery request, CancellationToken cancellationToken)
            {
                var response = new List<SeccionComponeteEvaluacionModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_SECCIONCOMPONENTES", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    SeccionComponeteEvaluacionModel model = new SeccionComponeteEvaluacionModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_periodo_academico = sqlReader.GetString(1);
                                    model.id_seccion = sqlReader.GetString(2);
                                    model.id_calificacion_padre = sqlReader.GetString(3);
                                    model.id_calificacion = sqlReader.GetString(4);
                                    model.codigo_calificacion = sqlReader.GetString(5);
                                    model.nombre_calificacion = sqlReader.GetString(6);
                                    model.indicador_calculada = sqlReader.GetString(7);
                                    model.formula = sqlReader.GetString(8);
                                    model.porcentaje = Convert.ToString(sqlReader.GetDecimal(9));
                                    model.orden_prueba = sqlReader.GetString(10);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetSeccionComponentesEvaluacionQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
