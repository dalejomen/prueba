using Ibero.Services.Avaya.Domain.Banner.Models;
using Ibero.Services.Avaya.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ibero.Services.Avaya.Domain.Banner.Queries
{
    public class GetDataSIGIIPQuery : IRequest<List<SIGIIPModel>>
    {
        public class Handler : IRequestHandler<GetDataSIGIIPQuery, List<SIGIIPModel>>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("Banner");
            }
            public async Task<List<SIGIIPModel>> Handle(GetDataSIGIIPQuery request, CancellationToken cancellationToken)
            {
                List<SIGIIPModel> LSM = new List<SIGIIPModel>();
                var infoDB = "";
                var JsonRequest = JsonConvert.SerializeObject(request);
                
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_SIGIIP", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 2;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    SIGIIPModel SM = new SIGIIPModel();
                                    SM.Id = Int32.Parse(sqlReader[0].ToString());
                                    SM.Id_Banner = sqlReader[1].ToString();
                                    SM.Apellidos = sqlReader[2].ToString();
                                    SM.Primer_Nombre = sqlReader[3].ToString();
                                    SM.Segundo_Nombre = sqlReader[4].ToString();
                                    SM.Identifiacion = sqlReader[5].ToString();
                                    SM.Tipo_Documento = sqlReader[6].ToString();
                                    SM.Codigo_Ciudad = Int32.Parse(sqlReader[7].ToString());
                                    SM.Nombre_Ciudad = sqlReader[8].ToString();
                                    SM.Codigo_Departamento = Int32.Parse(sqlReader[9].ToString());
                                    SM.Nombre_Departamento = sqlReader[10].ToString();
                                    SM.Codigo_Pais = sqlReader[11].ToString();
                                    SM.Nombre_Pais = sqlReader[12].ToString();
                                    SM.Email_Institucional  = sqlReader[13].ToString();
                                    SM.Fecha_Nacimiento = sqlReader[14].ToString();
                                    SM.Genero = sqlReader[15].ToString();
                                    SM.Estado = sqlReader[16].ToString();
                                    SM.Tipo = sqlReader[17].ToString();
                                    SM.Periodo = sqlReader[18].ToString();
                                    SM.Codigo_Programa = sqlReader[19].ToString();
                                    SM.Programa = sqlReader[20].ToString();
                                    SM.Facultad = sqlReader[21].ToString();
                                    SM.Nivel = sqlReader[22].ToString();
                                    SM.Modalidad = sqlReader[23].ToString();

                                    LSM.Add(SM);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetStatusGradePersonQuery), ex.Message, ex.Message);
                }
                return LSM;
            }
        }
    }
}
