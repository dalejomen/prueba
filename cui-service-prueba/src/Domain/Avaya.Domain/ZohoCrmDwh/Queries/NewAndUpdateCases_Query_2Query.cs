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
    public class NewAndUpdateCases_Query_2Query : IRequest<object>
    {
        public string CaseNumber { get; set; }
        public string CaseNumberText { get; set; }
        public string CaseId { get; set; }
        public string CreatedBy { get; set; }
        public string StatusCreatedBy { get; set; }
        public string CaseOwner { get; set; }
        public string DeptoResponsableCaso { get; set; }
        public string Supervisor { get; set; }
        public string EmailCreatedBy { get; set; }
        public string Type { get; set; }
        public string TypeApproval { get; set; }
        public string TypeGoodsOrBadCases { get; set; }
        public string Category { get; set; }
        public string CaseReason { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondSurname { get; set; }
        public string IdentificationNumber { get; set; }
        public string BannerStudentId { get; set; }
        public string Faculty { get; set; }
        public string Degree { get; set; }
        public string DegreeModalidad { get; set; }
        public string DegreeTypeName { get; set; }
        public string Subject { get; set; }
        public string CreatedTime { get; set; }
        public string ModifiedTime { get; set; }
        public string ExpectedClosingDate { get; set; }
        public string ClosedTime { get; set; }
        public string TasksCompletedTime { get; set; }
        public string FechaDeCierre { get; set; }
        public string SLACase { get; set; }
        public decimal? BusinessDays { get; set; }
        public int? CaseDaysToClose { get; set; }
        public string Status { get; set; }
        public string StatusCaseOpenClose { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public string CaseOrigin { get; set; }
        public string NivelDeAntiguedad { get; set; }
        public int? CantComentarios { get; set; }
        public string Tag { get; set; }
        public string EmailSource { get; set; }
        public int? CountSolicitud { get; set; }
        public int? CountQuejaoReclamo { get; set; }
        public int? CountProblema { get; set; }
        public int? CountPregunta { get; set; }
        public int? CountDerechosDePeticion { get; set; }
        public int? CountTutelas { get; set; }
        public int? CountRequerimientoDeAutoridad { get; set; }
        public int? CountTramites { get; set; }
        public int? CountCases { get; set; }
        public int? Buenos { get; set; }
        public int? Malos { get; set; }
        public string NivelDeAtencion { get; set; }
        public int? CountCasoAbierto { get; set; }
        public int? CountCasoCerrado { get; set; }
        public string MotivoDeDevolucionAbono { get; set; }
        public int? CountHomologaciones { get; set; }
        public string Reason { get; set; }
        public string IDC { get; set; }
        public string DealID { get; set; }
        public string LaydownDate { get; set; }
        public string ProcessingTime { get; set; }
        public string Approved { get; set; }
        public string RegionIbero { get; set; }
        public int? CantTasaDeRespuesta { get; set; }
        public string FechaRespuestaDeSatisfaccion { get; set; }
        public string RespuestaDeSatisfaccion { get; set; }
        public int? CantSatisfechos { get; set; }
        public int? CantNoSatisfechos { get; set; }
        public string ObservacionesRespuestaDeSatisfaccion { get; set; }
        public string Operador { get; set; }
        public string EstadoRenovacion { get; set; }
        public string EstadoLegalizacion { get; set; }


        public class Handler : IRequestHandler<NewAndUpdateCases_Query_2Query, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;


            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("ZohoDb");
            }
            public async Task<object> Handle(NewAndUpdateCases_Query_2Query request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("ZOHO_SP_Insert_Update_Cases_Query_2", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Case_Number", SqlDbType.VarChar).Value = request.CaseNumber;
                            cmd.Parameters.Add("@Case_Number_Text", SqlDbType.VarChar).Value = request.CaseNumberText;
                            cmd.Parameters.Add("@Case_Id", SqlDbType.VarChar).Value = request.CaseId;
                            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar).Value = request.CreatedBy;
                            cmd.Parameters.Add("@Status_Created_By", SqlDbType.VarChar).Value = request.StatusCreatedBy;
                            cmd.Parameters.Add("@Case_Owner", SqlDbType.VarChar).Value = request.CaseOwner;
                            cmd.Parameters.Add("@Depto_Responsable_Caso", SqlDbType.VarChar).Value = request.DeptoResponsableCaso;
                            cmd.Parameters.Add("@Supervisor", SqlDbType.VarChar).Value = request.Supervisor;
                            cmd.Parameters.Add("@Email_Created_By", SqlDbType.VarChar).Value = request.EmailCreatedBy;
                            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = request.Type;
                            cmd.Parameters.Add("@Type_Approval", SqlDbType.VarChar).Value = request.TypeApproval;
                            cmd.Parameters.Add("@Type_Goods_or_Bad_Cases", SqlDbType.VarChar).Value = request.TypeGoodsOrBadCases;
                            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = request.Category;
                            cmd.Parameters.Add("@Case_Reason", SqlDbType.VarChar).Value = request.CaseReason;
                            cmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = request.FirstName;
                            cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar).Value = request.MiddleName;
                            cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = request.LastName;
                            cmd.Parameters.Add("@Second_Surname", SqlDbType.VarChar).Value = request.SecondSurname;
                            cmd.Parameters.Add("@Identification_Number", SqlDbType.VarChar).Value = request.IdentificationNumber;
                            cmd.Parameters.Add("@Banner_Student_ID", SqlDbType.VarChar).Value = request.BannerStudentId;
                            cmd.Parameters.Add("@Faculty", SqlDbType.VarChar).Value = request.Faculty;
                            cmd.Parameters.Add("@Degree", SqlDbType.VarChar).Value = request.Degree;
                            cmd.Parameters.Add("@Degree_Modalidad", SqlDbType.VarChar).Value = request.DegreeModalidad;
                            cmd.Parameters.Add("@Degree_Type_Name", SqlDbType.VarChar).Value = request.DegreeTypeName;
                            cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = request.Subject;
                            cmd.Parameters.Add("@Created_Time", SqlDbType.VarChar).Value = request.CreatedTime;
                            cmd.Parameters.Add("@Modified_Time", SqlDbType.VarChar).Value = request.ModifiedTime;
                            cmd.Parameters.Add("@Expected_Closing_Date", SqlDbType.VarChar).Value = request.ExpectedClosingDate;
                            cmd.Parameters.Add("@Closed_Time", SqlDbType.VarChar).Value = request.ClosedTime;
                            cmd.Parameters.Add("@Tasks_Completed_Time", SqlDbType.VarChar).Value = request.TasksCompletedTime;
                            cmd.Parameters.Add("@Fecha_de_cierre", SqlDbType.VarChar).Value = request.FechaDeCierre;
                            cmd.Parameters.Add("@SLA_CASE", SqlDbType.VarChar).Value = request.SLACase;
                            cmd.Parameters.Add("@Business_Days", SqlDbType.Decimal).Value = request.BusinessDays.HasValue ? request.BusinessDays.Value : -1;
                            cmd.Parameters.Add("@Case_Days_to_Close", SqlDbType.Int).Value = request.CaseDaysToClose.HasValue ? request.CaseDaysToClose.Value : -1;
                            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = request.Status;
                            cmd.Parameters.Add("@Status_Case_OpenClose", SqlDbType.VarChar).Value = request.StatusCaseOpenClose;
                            cmd.Parameters.Add("@Priority", SqlDbType.VarChar).Value = request.Priority;
                            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = request.Description;
                            cmd.Parameters.Add("@Solution", SqlDbType.VarChar).Value = request.Solution;
                            cmd.Parameters.Add("@Case_origin", SqlDbType.VarChar).Value = request.CaseOrigin;
                            cmd.Parameters.Add("@Nivel_de_Antiguedad", SqlDbType.VarChar).Value = request.NivelDeAntiguedad;
                            cmd.Parameters.Add("@Cant_Comentarios", SqlDbType.Int).Value = request.CantComentarios.HasValue ? request.CantComentarios.Value : -1;
                            cmd.Parameters.Add("@Tag", SqlDbType.VarChar).Value = request.Tag;
                            cmd.Parameters.Add("@Email_Source", SqlDbType.VarChar).Value = request.EmailSource;
                            cmd.Parameters.Add("@CountSolicitud", SqlDbType.Int).Value = request.CountSolicitud.HasValue ? request.CountSolicitud.Value : -1;
                            cmd.Parameters.Add("@CountQuejaoReclamo", SqlDbType.Int).Value = request.CountQuejaoReclamo.HasValue ? request.CountQuejaoReclamo.Value : -1;
                            cmd.Parameters.Add("@CountProblema", SqlDbType.Int).Value = request.CountProblema.HasValue ? request.CountProblema.Value : -1;
                            cmd.Parameters.Add("@CountPregunta", SqlDbType.Int).Value = request.CountPregunta.HasValue ? request.CountPregunta.Value : -1;
                            cmd.Parameters.Add("@CountDerechosDePeticion", SqlDbType.Int).Value = request.CountDerechosDePeticion.HasValue ? request.CountDerechosDePeticion.Value : -1;
                            cmd.Parameters.Add("@CountTutelas", SqlDbType.Int).Value = request.CountTutelas.HasValue ? request.CountTutelas.Value : -1;
                            cmd.Parameters.Add("@CountRequerimientoDeAutoridad", SqlDbType.Int).Value = request.CountRequerimientoDeAutoridad.HasValue ? request.CountRequerimientoDeAutoridad.Value : -1;
                            cmd.Parameters.Add("@CountTramites", SqlDbType.Int).Value = request.CountTramites.HasValue ? request.CountTramites.Value : -1;
                            cmd.Parameters.Add("@CountCases", SqlDbType.Int).Value = request.CountCases.HasValue ? request.CountCases.Value : -1;
                            cmd.Parameters.Add("@Buenos", SqlDbType.Int).Value = request.Buenos.HasValue ? request.Buenos.Value : -1;
                            cmd.Parameters.Add("@Malos", SqlDbType.Int).Value = request.Malos.HasValue ? request.Malos.Value : -1;
                            cmd.Parameters.Add("@NIVEL_DE_ATENCION", SqlDbType.VarChar).Value = request.NivelDeAtencion;
                            cmd.Parameters.Add("@Count_Caso_Abierto", SqlDbType.Int).Value = request.CountCasoAbierto.HasValue ? request.CountCasoAbierto.Value : -1;
                            cmd.Parameters.Add("@Count_Caso_Cerrado", SqlDbType.Int).Value = request.CountCasoCerrado.HasValue ? request.CountCasoCerrado.Value : -1;
                            cmd.Parameters.Add("@Motivo_de_Devolucion_Abono", SqlDbType.VarChar).Value = request.MotivoDeDevolucionAbono;
                            cmd.Parameters.Add("@Count_Homologaciones", SqlDbType.Int).Value = request.CountHomologaciones.HasValue ? request.CountHomologaciones.Value : -1;
                            cmd.Parameters.Add("@Reason", SqlDbType.VarChar).Value = request.Reason;
                            cmd.Parameters.Add("@IDC", SqlDbType.VarChar).Value = request.IDC;
                            cmd.Parameters.Add("@Deal_ID", SqlDbType.VarChar).Value = request.DealID;
                            cmd.Parameters.Add("@Laydown_Date", SqlDbType.VarChar).Value = request.LaydownDate;
                            cmd.Parameters.Add("@Processing_Time", SqlDbType.VarChar).Value = request.ProcessingTime;
                            cmd.Parameters.Add("@Aproved", SqlDbType.VarChar).Value = request.Approved;
                            cmd.Parameters.Add("@Region_Ibero", SqlDbType.VarChar).Value = request.RegionIbero;
                            cmd.Parameters.Add("@Cant_Tasa_de_Respuesta", SqlDbType.Int).Value = request.CantTasaDeRespuesta.HasValue ? request.CantTasaDeRespuesta.Value : -1;
                            cmd.Parameters.Add("@Fecha_Respuesta_de_Satisfacción", SqlDbType.VarChar).Value = request.FechaRespuestaDeSatisfaccion;
                            cmd.Parameters.Add("@Respuesta_de_Satisfacción", SqlDbType.VarChar).Value = request.RespuestaDeSatisfaccion;
                            cmd.Parameters.Add("@Cant_Satisfechos", SqlDbType.Int).Value = request.CantSatisfechos.HasValue ? request.CantSatisfechos.Value : -1;
                            cmd.Parameters.Add("@Cant_No_Satisfechos", SqlDbType.Int).Value = request.CantNoSatisfechos.HasValue ? request.CantNoSatisfechos.Value : -1;
                            cmd.Parameters.Add("@Observaciones_Respuesta_de_Satisfacción", SqlDbType.VarChar).Value = request.ObservacionesRespuestaDeSatisfaccion;
                            cmd.Parameters.Add("@OPERADOR", SqlDbType.VarChar).Value = request.Operador;
                            cmd.Parameters.Add("@Estado_Renovación", SqlDbType.VarChar).Value = request.EstadoRenovacion;
                            cmd.Parameters.Add("@Estado_Legalización", SqlDbType.VarChar).Value = request.EstadoLegalizacion;



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
