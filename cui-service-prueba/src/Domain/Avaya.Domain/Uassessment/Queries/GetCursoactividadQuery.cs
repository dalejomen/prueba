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
    public class GetCursoactividadQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetCursoactividadQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetCursoactividadQuery request, CancellationToken cancellationToken)
            {
                var response = new List<CursoActividadModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CURSOACTIVIDAD", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    CursoActividadModel model = new CursoActividadModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_curso = sqlReader.GetString(1);
                                    model.id_actividad = sqlReader.GetString(2);
                                    model.codigo_actividad = sqlReader.GetString(3);
                                    model.nombre_actividad = sqlReader.GetString(4);
                                    model.numero_bloques_semana = Convert.ToString(sqlReader.GetInt32(5));
                                    model.id_modalidad = sqlReader.GetString(6);
                                    model.codigo_modalidad = sqlReader.GetString(7);
                                    model.nombre_modalidad = sqlReader.GetString(8);
                                    model.numero_horas_semanales = sqlReader.GetString(9);
                                    model.numero_horas_consecutivas = sqlReader.GetString(10);
                                    
                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetCursoactividadQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
