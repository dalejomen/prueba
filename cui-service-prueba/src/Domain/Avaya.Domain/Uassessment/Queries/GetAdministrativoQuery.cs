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
    public class GetAdministrativoQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetAdministrativoQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetAdministrativoQuery request, CancellationToken cancellationToken)
            {
                var response = new List<AdministrativoModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ADMINISTRATIVOS", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    AdministrativoModel model = new AdministrativoModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_administrativo = sqlReader.GetString(1);
                                    model.codigo_administrativo = sqlReader.GetString(2);
                                    model.username = sqlReader.GetString(3);
                                    model.nombres = sqlReader.GetString(4);
                                    model.apellido_paterno = sqlReader.GetString(5);
                                    model.apellido_materno = sqlReader.GetString(6);
                                    model.correo_electronico_administrativo = sqlReader.GetString(7);
                                    model.id_departamento = sqlReader.GetString(8);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetAdministrativoQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
