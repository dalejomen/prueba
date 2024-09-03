using AutoMapper;
using Ibero.Services.Avaya.Core.Entities;
using Ibero.Services.Avaya.Core.Models;
using Ibero.Services.Avaya.Domain.Exceptions;
using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
using Ibero.Services.Avaya.Domain.Infrastructure.Configuration;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Ibero.Services.Avaya.Domain.ZohoCrmDwh.Queries
{
    public class NewAndUpdateZoomExport : IRequest<object>
    {
        public int ID_CLIENTE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string DOCUMENTO { get; set; }
        public string MODALIDAD { get; set; }
        public string PROGRAMA { get; set; }
        public string FACULTAD { get; set; }
        public string NIVEL_FORMACION { get; set; }
        public string OPERADOR { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public string TELEFONO { get; set; }
        public string GENERO { get; set; }
        public string EMAIL_PERSONAL { get; set; }
        public string CELULAR { get; set; }
        public string EMAIL_INSTITUCIONAL { get; set; }
        public string ESTADO_ACADEMICO { get; set; }
        public string DIRECCION { get; set; }
        public string CIUDAD { get; set; }
        public string PERIODO_INGRESO { get; set; }
        public string SEMESTRE_CREDITOS { get; set; }
        public int ULTIMA_MATRICULA { get; set; }
        public string PERIODO_ENCUESTA { get; set; }
        public DateTime FECHA_RESPUESTA { get; set; }
        public string FECHA_HORA_RESPUESTA { get; set; }
        public string NOMBRE_ENCUESTA { get; set; }
        public decimal P1_QUE_PROBABILIDAD_HAY_DE_QUE_RECOMIENDES_LA_IBERO_A_UN_AMIGO_O_COMPANERO { get; set; }
        public string P2_CUAL_ES_LA_RAZON_PRINCIPAL_DE_TU_CALIFICACION { get; set; }
        public int ORDEN { get; set; }


        public class Handler : IRequestHandler<NewAndUpdateZoomExport, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;


            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("Modelo_Predictivo");
            }
            public async Task<object> Handle(NewAndUpdateZoomExport request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("ZOOM_SP_Insert_Update_ZoomExport", sql))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@ID_CLIENTE", SqlDbType.Int).Value = request.ID_CLIENTE;
                            cmd.Parameters.Add("@NOMBRES", SqlDbType.NVarChar).Value = request.NOMBRES ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@APELLIDOS", SqlDbType.NVarChar).Value = request.APELLIDOS ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@DOCUMENTO", SqlDbType.NVarChar).Value = request.DOCUMENTO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@MODALIDAD", SqlDbType.NVarChar).Value = request.MODALIDAD ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@PROGRAMA", SqlDbType.NVarChar).Value = request.PROGRAMA ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@FACULTAD", SqlDbType.NVarChar).Value = request.FACULTAD ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@NIVEL_FORMACION", SqlDbType.NVarChar).Value = request.NIVEL_FORMACION ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@OPERADOR", SqlDbType.NVarChar).Value = request.OPERADOR ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.NVarChar).Value = request.FECHA_NACIMIENTO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@TELEFONO", SqlDbType.NVarChar).Value = request.TELEFONO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@GENERO", SqlDbType.NVarChar).Value = request.GENERO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@EMAIL_PERSONAL", SqlDbType.NVarChar).Value = request.EMAIL_PERSONAL ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@CELULAR", SqlDbType.NVarChar).Value = request.CELULAR ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@EMAIL_INSTITUCIONAL", SqlDbType.NVarChar).Value = request.EMAIL_INSTITUCIONAL ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@ESTADO_ACADEMICO", SqlDbType.NVarChar).Value = request.ESTADO_ACADEMICO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@DIRECCION", SqlDbType.NVarChar).Value = request.DIRECCION ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@CIUDAD", SqlDbType.NVarChar).Value = request.CIUDAD ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@PERIODO_INGRESO", SqlDbType.NVarChar).Value = request.PERIODO_INGRESO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@SEMESTRE_CREDITOS", SqlDbType.NVarChar).Value = request.SEMESTRE_CREDITOS ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@ULTIMA_MATRICULA", SqlDbType.Int).Value = request.ULTIMA_MATRICULA;
                            cmd.Parameters.Add("@PERIODO_ENCUESTA", SqlDbType.NVarChar).Value = request.PERIODO_ENCUESTA ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@FECHA_RESPUESTA", SqlDbType.DateTime).Value = request.FECHA_RESPUESTA;
                            cmd.Parameters.Add("@FECHA_HORA_RESPUESTA", SqlDbType.NVarChar).Value = request.FECHA_HORA_RESPUESTA ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@NOMBRE_ENCUESTA", SqlDbType.NVarChar).Value = request.NOMBRE_ENCUESTA ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@P1_QUE_PROBABILIDAD_HAY_DE_QUE_RECOMIENDES_LA_IBERO_A_UN_AMIGO_O_COMPANERO", SqlDbType.Decimal).Value = request.P1_QUE_PROBABILIDAD_HAY_DE_QUE_RECOMIENDES_LA_IBERO_A_UN_AMIGO_O_COMPANERO;
                            cmd.Parameters.Add("@P2_CUAL_ES_LA_RAZON_PRINCIPAL_DE_TU_CALIFICACION", SqlDbType.NVarChar).Value = request.P2_CUAL_ES_LA_RAZON_PRINCIPAL_DE_TU_CALIFICACION ?? (object)DBNull.Value;
                            cmd.Parameters.Add("@ORDEN", SqlDbType.Int).Value = request.ORDEN;

                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    infoDB += sqlReader[0].ToString();
                                }
                            }
                        }
                    }
                    response = infoDB;
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(NewAndUpdateCases_Query_2Query), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
