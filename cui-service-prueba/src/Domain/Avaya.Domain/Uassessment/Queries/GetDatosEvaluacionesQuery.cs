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
    public class GetDatosEvaluacionesQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetDatosEvaluacionesQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetDatosEvaluacionesQuery request, CancellationToken cancellationToken)
            {
                var response = new List<DatosEvaluacioneModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_DATOSEVALUACIONES", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    DatosEvaluacioneModel model = new DatosEvaluacioneModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_estudiante = sqlReader.GetString(1);
                                    model.id_campus = sqlReader.GetString(2);
                                    model.id_periodo_academico = sqlReader.GetString(3);
                                    model.id_jornada = sqlReader.GetString(4);
                                    model.id_seccion = sqlReader.GetString(5);                                    
                                    model.nm_nota_obtenida = sqlReader.GetString(6);
                                    model.nm_nota_obtenida_porcentual = Convert.ToString(sqlReader.GetInt32(7));
                                    model.id_calificacion = sqlReader.GetString(8);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetDatosEvaluacionesQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
