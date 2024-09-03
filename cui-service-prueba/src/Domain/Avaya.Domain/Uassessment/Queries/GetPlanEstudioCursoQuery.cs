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
    public class GetPlanEstudioCursoQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetPlanEstudioCursoQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetPlanEstudioCursoQuery request, CancellationToken cancellationToken)
            {
                var response = new List<PalnEstudioCursoModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_PLANESTUDIOCURSO", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    PalnEstudioCursoModel model = new PalnEstudioCursoModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_plan = sqlReader.GetString(1);
                                    model.id_curso = sqlReader.GetString(2);
                                    model.numero_nivel = sqlReader.GetString(3);
                                    model.prerrequisitos_curso = sqlReader.GetString(4);
                                    model.correquisitos_curso = sqlReader.GetString(5);
                                    model.equivalencias_curso = sqlReader.GetString(6);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetPlanEstudioCursoQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
