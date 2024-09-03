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
    public class GetPlanEstudioQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetPlanEstudioQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetPlanEstudioQuery request, CancellationToken cancellationToken)
            {
                var response = new List<PlanEstudioModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_PLANESTUDIO", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    PlanEstudioModel model = new PlanEstudioModel();
                                    model.Id = sqlReader.GetInt32(0);
                                    model.id_plan_estudio = sqlReader.GetString(1);
                                    model.codigo_plan_estudio = sqlReader.GetString(2);
                                    model.nombre_plan_estudio = sqlReader.GetString(3);
                                    model.id_carrera = sqlReader.GetString(4);
                                    model.id_modalidad = sqlReader.GetString(5);
                                    model.nombre_modalidad = sqlReader.GetString(6);
                                    model.anio_plan_estudio = sqlReader.GetString(7);
                                    model.numero_creditos_plan_estudio = sqlReader.GetInt32(8);
                                    model.numero_creditos_periodo = sqlReader.GetInt32(9);
                                    model.codigo_tipo_periodo_academico = sqlReader.GetString(10);
                                    model.vigencia_fecha_ini = sqlReader.GetString(11);
                                    model.vigencia_fecha_fin = sqlReader.GetString(12);
                                    model.numero_minimo_anios = sqlReader.GetString(13);
                                    model.perfil_ingreso = sqlReader.GetString(14);
                                    model.perfil_egreso = sqlReader.GetString(15);
                                    model.codigo_version_plan_estudio_actual = sqlReader.GetString(16);
                                    model.codigo_version_plan_estudio_anterior = sqlReader.GetString(17);
                                    model.indicador_version_actual = sqlReader.GetInt32(18);


                                    response.Add(model);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetPlanEstudioQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
