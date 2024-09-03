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
    public class GetGetSeccionQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetGetSeccionQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetGetSeccionQuery request, CancellationToken cancellationToken)
            {
                var response = new List<SeccionModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_SECCION", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    SeccionModel model = new SeccionModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_campus = sqlReader.GetString(1);
                                    model.id_periodo_academico = sqlReader.GetString(2);
                                    model.id_jornada = sqlReader.GetString(3);

                                    model.id_seccion = sqlReader.GetString(4);
                                    model.codigo_seccion = sqlReader.GetString(5);
                                    model.nombre_seccion = sqlReader.GetString(6);

                                    model.codigo_grupo = sqlReader.GetString(7);
                                    model.nro_inscritos = sqlReader.GetString(8);
                                    model.id_lista_cruzada = sqlReader.GetString(9);

                                    model.indicador_curso_principal = sqlReader.GetString(10);
                                    model.id_curso = sqlReader.GetString(11);
                                    model.nombre_curso = sqlReader.GetString(12);

                                    model.id_actividad = sqlReader.GetString(13);
                                    model.nombre_actividad = sqlReader.GetString(14);
                                    model.id_liga = sqlReader.GetString(15);

                                    model.indicador_seccion_padre = sqlReader.GetString(16);
                                    model.id_modalidad = sqlReader.GetString(17);
                                    model.nombre_modalidad = sqlReader.GetString(18);
                                    model.id_idioma = sqlReader.GetString(19);
                                    model.nombre_idioma = sqlReader.GetString(20);


                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetGetSeccionQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
