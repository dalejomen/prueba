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
    public class GetDatosInscripcionesQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetDatosInscripcionesQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetDatosInscripcionesQuery request, CancellationToken cancellationToken)
            {
                var response = new List<DatosInscripcionesModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_DATOSINSCRIPCIONES", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    DatosInscripcionesModel model = new DatosInscripcionesModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_estudiante = sqlReader.GetString(1);
                                    model.id_campus = sqlReader.GetString(2);
                                    model.id_periodo_academico = sqlReader.GetString(3);
                                    model.id_jornada = sqlReader.GetString(4);
                                    model.id_curso_inscrito = sqlReader.GetString(5);
                                    model.id_estado_inscripcion = sqlReader.GetString(6);
                                    model.nota_final = sqlReader.GetString(7);
                                    model.nota_final_porcentual = Convert.ToString(sqlReader.GetInt32(8));
                                   

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetDatosInscripcionesQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
