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
    public class GetDocenteSeccionQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetDocenteSeccionQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetDocenteSeccionQuery request, CancellationToken cancellationToken)
            {
                var response = new List<DocenteSeccionModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_DOCENTESECCION", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    DocenteSeccionModel model = new DocenteSeccionModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_periodo_academico = sqlReader.GetString(1);
                                    model.id_seccion = sqlReader.GetString(2);
                                    model.id_docente = sqlReader.GetString(3);
                                    model.ind_principal =Convert.ToString( sqlReader.GetInt32(4));
                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetDocenteSeccionQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
