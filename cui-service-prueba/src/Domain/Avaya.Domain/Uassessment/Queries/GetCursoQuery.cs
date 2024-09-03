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
    public class GetCursoQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetCursoQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetCursoQuery request, CancellationToken cancellationToken)
            {
                var response = new List<CursoModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CURSO", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    CursoModel model = new CursoModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_curso = sqlReader.GetString(1);
                                    model.codigo_curso = sqlReader.GetString(2);
                                    model.nombre_curso = sqlReader.GetString(3);
                                    model.id_departamento = sqlReader.GetString(4);
                                    model.id_nivel_curso = sqlReader.GetString(5);
                                    model.numero_creditos = sqlReader.GetInt32(6);
                                    model.codigo_version_curso_actual = sqlReader.GetString(7);
                                    model.codigo_version_curso_anterior = sqlReader.GetString(8);
                                    model.indicador_version_actual = sqlReader.GetInt32(9);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetCursoQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
