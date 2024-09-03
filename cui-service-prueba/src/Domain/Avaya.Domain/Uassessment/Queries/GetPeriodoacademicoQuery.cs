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
    public class GetPeriodoacademicoQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetPeriodoacademicoQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetPeriodoacademicoQuery request, CancellationToken cancellationToken)
            {
                var response = new List<PeriodoacademicoModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_PERIODO_ACADEMICO", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    PeriodoacademicoModel model = new PeriodoacademicoModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_periodo_academico = sqlReader.GetString(1);
                                    model.codigo_periodo_academico = sqlReader.GetString(2);
                                    model.nombre_periodo_academico = sqlReader.GetString(3);
                                    model.codigo_tipo_periodo_academico = sqlReader.GetString(4);
                                    model.nombre_tipo_periodo_academico = sqlReader.GetString(5);
                                    model.agno_periodo_academico = sqlReader.GetString(6);
                                    model.numero_semanas = sqlReader.GetInt32(7);
                                    model.fecha_inicio_periodo = sqlReader.GetString(8);
                                    model.fecha_fin_periodo = sqlReader.GetString(9);
                                    model.indicador_actual = sqlReader.GetString(10);
                                    model.indicador_programable = sqlReader.GetString(11);

                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetPeriodoacademicoQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
