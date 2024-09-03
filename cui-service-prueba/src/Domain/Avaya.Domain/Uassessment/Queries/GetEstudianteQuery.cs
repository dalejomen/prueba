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
    public class GetEstudianteQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetEstudianteQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetEstudianteQuery request, CancellationToken cancellationToken)
            {
                var response = new List<EstudianteModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ESTUDIANTE", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    EstudianteModel model = new EstudianteModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_estudiante = sqlReader.GetString(1);
                                    model.codigo_estudiante = sqlReader.GetString(2);
                                    model.username = sqlReader.GetString(3);
                                    model.nombres_estudiante = sqlReader.GetString(4);
                                    model.apellido_paterno = sqlReader.GetString(5);
                                    model.apellido_materno = sqlReader.GetString(6);
                                    model.telefono_estudiante = sqlReader.GetString(7);
                                    model.correo_electronico_estudiante = sqlReader.GetString(8);
                                    model.direccion_estudiante = sqlReader.GetString(9);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetEstudianteQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
