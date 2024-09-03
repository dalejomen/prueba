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
    public class GetCarreraQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetCarreraQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetCarreraQuery request, CancellationToken cancellationToken)
            {
                var response = new List<CarreraModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CARRERA", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    CarreraModel model = new CarreraModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_carrera = sqlReader.GetString(1);
                                    model.codigo_carrera = sqlReader.GetString(2);
                                    model.nombre_carrera = sqlReader.GetString(3);
                                    model.id_facultad = sqlReader.GetString(4);
                                    model.id_tipo_carrera = sqlReader.GetString(5);
                                    model.codigo_tipo_carrera = sqlReader.GetString(6);
                                    model.nombre_tipo_carrera = sqlReader.GetString(7);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetCarreraQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
