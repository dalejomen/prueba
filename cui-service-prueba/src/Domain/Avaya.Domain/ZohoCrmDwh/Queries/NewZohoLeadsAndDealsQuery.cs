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
    public class NewZohoLeadsAndDealsQuery : IRequest<object>
    {
        public Int64 POTENTIALID { get; set; }
        public Int64 POTENTIAL_ID { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Identification_Number { get; set; }
        public string Banner_Student_ID { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Primary_Email { get; set; }
        public string Secondary_Email { get; set; }
        public string Lead_Id { get; set; }
        public string Lead_source { get; set; }
        public string Owner { get; set; }
        public string Owner_Email { get; set; }
        public string Owner_Status { get; set; }
        public string Owner_ID { get; set; }
        public string Supervisor { get; set; }
        public string Canal_Owner { get; set; }
        public string Depto_Owner { get; set; }
        public string Created_by { get; set; }
        public string Academic_Period_Code { get; set; }
        public string Ingreso { get; set; }
        public string Stage { get; set; }
        public string Tipo_Etapa { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string Tipo2 { get; set; }
        public string Contacto { get; set; }
        public string Gone_To_Competitor_Reason { get; set; }
        public string University_Name { get; set; }
        public string Reason_for_Conversion_Failure { get; set; }
        public string Bad_Lead_Reason { get; set; }
        public string Deals_Not_Aproved_Reasons_Name { get; set; }
        public string Not_Interested_Reason { get; set; }
        public string Close_Lost_Reasons { get; set; }
        public string Created_Time { get; set; }
        public string Tasks_Involved { get; set; }
        public string TasksOnly { get; set; }
        public string Forecast_Type { get; set; }
        public string Modified_Time { get; set; }
        public string Ultima_Actividad { get; set; }
        public string Close_Date { get; set; }
        public string Payment_Date { get; set; }
        public string Faculty_name { get; set; }
        public string Degree_Name { get; set; }
        public string Degree_Code { get; set; }
        public string Modalidad { get; set; }
        public string Nivel_Degree { get; set; }
        public string Require_Homologation { get; set; }
        public string ULTIMA_ACTIVIDAD_ESTADO { get; set; }
        public string Fecha_Creacion_Operacion { get; set; }
        public string AnoMes_Creacion_Operacion { get; set; }
        public string Account_Name { get; set; }
        public string H_Modified_Time { get; set; }
        public string H_Stage { get; set; }
        public string Vendor_Name { get; set; }
        public string Territory_Name { get; set; }
        public string Region_Ibero { get; set; }
        public string Depto_Ibero { get; set; }
        public string Sales_Force_Name { get; set; }
        public string Unificada2 { get; set; }
        public string Count_Digital { get; set; }
        public string Count_Leads { get; set; }
        public string Count_L { get; set; }
        public string Count_Matriculas { get; set; }
        public string Count_Gestionados { get; set; }
        public string Count_Tratos_de_Leads { get; set; }
        public string CC_PER_PROGR { get; set; }
        public string CC_PER { get; set; }
        public string Amount { get; set; }
        public string City { get; set; }
        public string Intentos { get; set; }
        public string Sourse_Agrupacion1 { get; set; }
        public string Reopened { get; set; }
        public string Tag { get; set; }
        public string First_Touch { get; set; }
        public string First_ContactD { get; set; }
        public string Medicion_Agencia_Mk { get; set; }
        public string Academic_Period_Posponed { get; set; }
        public string Jornada { get; set; }
        public string Count_Lead_Digital { get; set; }
        public string Count_LYD_Digital { get; set; }
        public string Count_Lead_Orgánico { get; set; }
        public string Count_LYD_Orgánico { get; set; }
        public string Count_Lead_Proveedores { get; set; }
        public string Count_LYD_Proveedores { get; set; }
        public string Sorce_Unificada3 { get; set; }
        public string Sorce_Unificada4 { get; set; }
        public string Sorce_Unificada5 { get; set; }
        public string Sorce_Unificada6 { get; set; }
        public string Leads_Gestionados { get; set; }
        public string Leads_Contactados { get; set; }
        public string LYD_Contactados { get; set; }
        public string Leads_Conver_trato { get; set; }
        public string LYD_en_trato { get; set; }
        public string Leads_Inscritos { get; set; }
        public string LYD_Inscritos { get; set; }
        public string Leads_Admitidos { get; set; }
        public string LYD_Admitidos { get; set; }
        public string Leads_Pend_Pago { get; set; }
        public string LYD_Pend_Pago { get; set; }
        public string Leads_Efectivos { get; set; }
        public string LYD_Efectivos { get; set; }
        public string Compromisos { get; set; }
        public string Admitidos_con_Compromiso { get; set; }
        public string Admitidos_y_superiores { get; set; }
        public string Mobile_Original { get; set; }
        public string Phone_Original { get; set; }
        public string Count_Matricula_de_Lead_Digital { get; set; }
        public string Count_Matricula_de_Lead_Organico { get; set; }
        public string Count_Matricula_de_Lead_Proveedores { get; set; }
        public string Como_se_entero_de_la_ibero { get; set; }
        public string Sorce_Unificada31 { get; set; }
        public string Compendio_Motivos_De_No_Interes { get; set; }
        public string Count_Compendio_Motivos_De_No_Interes { get; set; }
        public string Degree_Type_de_Leads { get; set; }
        public string Count_Reopened { get; set; }
        public string FCL { get; set; }
        public string Reopened_Time { get; set; }
        public string Previous_Degree { get; set; }
        public string Payment_Mode { get; set; }
        public string Count_LYD_Abiertos { get; set; }
        public string Count_Leads_Abiertos { get; set; }
        public string Count_LYD_Cerrados { get; set; }
        public string HubSpotStageStatus { get; set; }
        public string HubSpotLeadStatus { get; set; }
        public string Lead_Status { get; set; }
        public string lifecylestage { get; set; }
        public string Operacion_Ibero { get; set; }
        public string TIEMPO_DE_MADURACION { get; set; }
        public string Date_of_Birth { get; set; }
        public string Cuenta_Tratos_antes_de_Admitidos { get; set; }
        public string Cuenta_Tratos_en_Admitidos { get; set; }
        public string Sales_Cycle_Duration { get; set; }
        public string DM { get; set; }
        public string Fecha_Captacion { get; set; }
        public string AnoMes_Captacion { get; set; }
        public string OPERACION { get; set; }
        public string PRECIO_PROGRAMA { get; set; }
        public string IS_RMK { get; set; }
        public string Metas_Fecha_Inicio_Ingreso { get; set; }
        public string Utm_Source { get; set; }
        public string Utm_Medium { get; set; }
        public string Utm_Content { get; set; }
        public string Utm_Campaign { get; set; }
        public string URL_Visited { get; set; }
        public string Tipo_Lead_Captacion { get; set; }
        public string ID_supervisor { get; set; }

        public class Handler : IRequestHandler<NewZohoLeadsAndDealsQuery, object>
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
            public async Task<object> Handle(NewZohoLeadsAndDealsQuery request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("ZOHO_SP_Intert_update_Analytics_Leads_and_Deals", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@POTENTIALID", SqlDbType.BigInt).Value = request.POTENTIALID;
                            cmd.Parameters.Add("@POTENTIAL_ID", SqlDbType.BigInt).Value = request.POTENTIAL_ID;
                            cmd.Parameters.Add("@Nombre_Cliente", SqlDbType.VarChar).Value = request.Nombre_Cliente;
                            cmd.Parameters.Add("@Identification_Number", SqlDbType.VarChar).Value = request.Identification_Number;
                            cmd.Parameters.Add("@Banner_Student_ID", SqlDbType.VarChar).Value = request.Banner_Student_ID;
                            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = request.Mobile;
                            cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = request.Phone;
                            cmd.Parameters.Add("@Primary_Email", SqlDbType.VarChar).Value = request.Primary_Email;
                            cmd.Parameters.Add("@Secondary_Email", SqlDbType.VarChar).Value = request.Secondary_Email;
                            cmd.Parameters.Add("@Lead_Id", SqlDbType.VarChar).Value = request.Lead_Id;
                            cmd.Parameters.Add("@Lead_source", SqlDbType.VarChar).Value = request.Lead_source;
                            cmd.Parameters.Add("@Owner", SqlDbType.VarChar).Value = request.Owner;
                            cmd.Parameters.Add("@Owner_Email", SqlDbType.VarChar).Value = request.Owner_Email;
                            cmd.Parameters.Add("@Owner_Status", SqlDbType.VarChar).Value = request.Owner_Status;
                            cmd.Parameters.Add("@Owner_ID", SqlDbType.VarChar).Value = request.Owner_ID;
                            cmd.Parameters.Add("@Supervisor", SqlDbType.VarChar).Value = request.Supervisor;
                            cmd.Parameters.Add("@Canal_Owner", SqlDbType.VarChar).Value = request.Canal_Owner;
                            cmd.Parameters.Add("@Depto_Owner", SqlDbType.VarChar).Value = request.Depto_Owner;
                            cmd.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = request.Created_by;
                            cmd.Parameters.Add("@Academic_Period_Code", SqlDbType.VarChar).Value = request.Academic_Period_Code;
                            cmd.Parameters.Add("@Ingreso", SqlDbType.VarChar).Value = request.Ingreso;
                            cmd.Parameters.Add("@Stage", SqlDbType.VarChar).Value = request.Stage;
                            cmd.Parameters.Add("@Tipo_Etapa", SqlDbType.VarChar).Value = request.Tipo_Etapa;
                            cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = request.Estado;
                            cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = request.Tipo;
                            cmd.Parameters.Add("@Tipo2", SqlDbType.VarChar).Value = request.Tipo2;
                            cmd.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = request.Contacto;
                            cmd.Parameters.Add("@Gone_To_Competitor_Reason", SqlDbType.VarChar).Value = request.Gone_To_Competitor_Reason;
                            cmd.Parameters.Add("@University_Name", SqlDbType.VarChar).Value = request.University_Name;
                            cmd.Parameters.Add("@Reason_for_Conversion_Failure", SqlDbType.VarChar).Value = request.Reason_for_Conversion_Failure;
                            cmd.Parameters.Add("@Bad_Lead_Reason", SqlDbType.VarChar).Value = request.Bad_Lead_Reason;
                            cmd.Parameters.Add("@Deals_Not_Aproved_Reasons_Name", SqlDbType.VarChar).Value = request.Deals_Not_Aproved_Reasons_Name;
                            cmd.Parameters.Add("@Not_Interested_Reason", SqlDbType.VarChar).Value = request.Not_Interested_Reason;
                            cmd.Parameters.Add("@Close_Lost_Reasons", SqlDbType.VarChar).Value = request.Close_Lost_Reasons;
                            cmd.Parameters.Add("@Created_Time", SqlDbType.VarChar).Value = request.Created_Time;
                            cmd.Parameters.Add("@Tasks_Involved", SqlDbType.VarChar).Value = request.Tasks_Involved;
                            cmd.Parameters.Add("@TasksOnly", SqlDbType.VarChar).Value = request.TasksOnly;
                            cmd.Parameters.Add("@Forecast_Type", SqlDbType.VarChar).Value = request.Forecast_Type;
                            cmd.Parameters.Add("@Modified_Time", SqlDbType.VarChar).Value = request.Modified_Time;
                            cmd.Parameters.Add("@Ultima_Actividad", SqlDbType.VarChar).Value = request.Ultima_Actividad;
                            cmd.Parameters.Add("@Close_Date", SqlDbType.VarChar).Value = request.Close_Date;
                            cmd.Parameters.Add("@Payment_Date", SqlDbType.VarChar).Value = request.Payment_Date;
                            cmd.Parameters.Add("@Faculty_name", SqlDbType.VarChar).Value = request.Faculty_name;
                            cmd.Parameters.Add("@Degree_Name", SqlDbType.VarChar).Value = request.Degree_Name;
                            cmd.Parameters.Add("@Degree_Code", SqlDbType.VarChar).Value = request.Degree_Code;
                            cmd.Parameters.Add("@Modalidad", SqlDbType.VarChar).Value = request.Modalidad;
                            cmd.Parameters.Add("@Nivel_Degree", SqlDbType.VarChar).Value = request.Nivel_Degree;
                            cmd.Parameters.Add("@Require_Homologation", SqlDbType.VarChar).Value = request.Require_Homologation;
                            cmd.Parameters.Add("@ULTIMA_ACTIVIDAD_ESTADO", SqlDbType.VarChar).Value = request.ULTIMA_ACTIVIDAD_ESTADO;
                            cmd.Parameters.Add("@Fecha_Creacion_Operacion", SqlDbType.VarChar).Value = request.Fecha_Creacion_Operacion;
                            cmd.Parameters.Add("@AnoMes_Creacion_Operacion", SqlDbType.VarChar).Value = request.AnoMes_Creacion_Operacion;
                            cmd.Parameters.Add("@Account_Name", SqlDbType.VarChar).Value = request.Account_Name;
                            cmd.Parameters.Add("@H_Modified_Time", SqlDbType.VarChar).Value = request.H_Modified_Time;
                            cmd.Parameters.Add("@H_Stage", SqlDbType.VarChar).Value = request.H_Stage;
                            cmd.Parameters.Add("@Vendor_Name", SqlDbType.VarChar).Value = request.Vendor_Name;
                            cmd.Parameters.Add("@Territory_Name", SqlDbType.VarChar).Value = request.Territory_Name;
                            cmd.Parameters.Add("@Region_Ibero", SqlDbType.VarChar).Value = request.Region_Ibero;
                            cmd.Parameters.Add("@Depto_Ibero", SqlDbType.VarChar).Value = request.Depto_Ibero;
                            cmd.Parameters.Add("@Sales_Force_Name", SqlDbType.VarChar).Value = request.Sales_Force_Name;
                            cmd.Parameters.Add("@Unificada2", SqlDbType.VarChar).Value = request.Unificada2;
                            cmd.Parameters.Add("@Count_Digital", SqlDbType.VarChar).Value = request.Count_Digital;
                            cmd.Parameters.Add("@Count_Leads", SqlDbType.VarChar).Value = request.Count_Leads;
                            cmd.Parameters.Add("@Count_L", SqlDbType.VarChar).Value = request.Count_L;
                            cmd.Parameters.Add("@Count_Matriculas", SqlDbType.VarChar).Value = request.Count_Matriculas;
                            cmd.Parameters.Add("@Count_Gestionados", SqlDbType.VarChar).Value = request.Count_Gestionados;
                            cmd.Parameters.Add("@Count_Tratos_de_Leads", SqlDbType.VarChar).Value = request.Count_Tratos_de_Leads;
                            cmd.Parameters.Add("@CC_PER_PROGR", SqlDbType.VarChar).Value = request.CC_PER_PROGR;
                            cmd.Parameters.Add("@CC_PER", SqlDbType.VarChar).Value = request.CC_PER;
                            cmd.Parameters.Add("@Amount", SqlDbType.VarChar).Value = request.Amount;
                            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = request.City;
                            cmd.Parameters.Add("@Intentos", SqlDbType.VarChar).Value = request.Intentos;
                            cmd.Parameters.Add("@Sourse_Agrupacion1", SqlDbType.VarChar).Value = request.Sourse_Agrupacion1;
                            cmd.Parameters.Add("@Reopened", SqlDbType.VarChar).Value = request.Reopened;
                            cmd.Parameters.Add("@Tag", SqlDbType.VarChar).Value = request.Tag;
                            cmd.Parameters.Add("@First_Touch", SqlDbType.VarChar).Value = request.First_Touch;
                            cmd.Parameters.Add("@First_ContactD", SqlDbType.VarChar).Value = request.First_ContactD;
                            cmd.Parameters.Add("@Medicion_Agencia_Mk", SqlDbType.VarChar).Value = request.Medicion_Agencia_Mk;
                            cmd.Parameters.Add("@Academic_Period_Posponed", SqlDbType.VarChar).Value = request.Academic_Period_Posponed;
                            cmd.Parameters.Add("@Jornada", SqlDbType.VarChar).Value = request.Jornada;
                            cmd.Parameters.Add("@Count_Lead_Digital", SqlDbType.VarChar).Value = request.Count_Lead_Digital;
                            cmd.Parameters.Add("@Count_LYD_Digital", SqlDbType.VarChar).Value = request.Count_LYD_Digital;
                            cmd.Parameters.Add("@Count_Lead_Orgánico", SqlDbType.VarChar).Value = request.Count_Lead_Orgánico;
                            cmd.Parameters.Add("@Count_LYD_Orgánico", SqlDbType.VarChar).Value = request.Count_LYD_Orgánico;
                            cmd.Parameters.Add("@Count_Lead_Proveedores", SqlDbType.VarChar).Value = request.Count_Lead_Proveedores;
                            cmd.Parameters.Add("@Count_LYD_Proveedores", SqlDbType.VarChar).Value = request.Count_LYD_Proveedores;
                            cmd.Parameters.Add("@Sorce_Unificada3", SqlDbType.VarChar).Value = request.Sorce_Unificada3;
                            cmd.Parameters.Add("@Sorce_Unificada4", SqlDbType.VarChar).Value = request.Sorce_Unificada4;
                            cmd.Parameters.Add("@Sorce_Unificada5", SqlDbType.VarChar).Value = request.Sorce_Unificada5;
                            cmd.Parameters.Add("@Sorce_Unificada6", SqlDbType.VarChar).Value = request.Sorce_Unificada6;
                            cmd.Parameters.Add("@Leads_Gestionados", SqlDbType.VarChar).Value = request.Leads_Gestionados;
                            cmd.Parameters.Add("@Leads_Contactados", SqlDbType.VarChar).Value = request.Leads_Contactados;
                            cmd.Parameters.Add("@LYD_Contactados", SqlDbType.VarChar).Value = request.LYD_Contactados;
                            cmd.Parameters.Add("@Leads_Conver_trato", SqlDbType.VarChar).Value = request.Leads_Conver_trato;
                            cmd.Parameters.Add("@LYD_en_trato", SqlDbType.VarChar).Value = request.LYD_en_trato;
                            cmd.Parameters.Add("@Leads_Inscritos", SqlDbType.VarChar).Value = request.Leads_Inscritos;
                            cmd.Parameters.Add("@LYD_Inscritos", SqlDbType.VarChar).Value = request.LYD_Inscritos;
                            cmd.Parameters.Add("@Leads_Admitidos", SqlDbType.VarChar).Value = request.Leads_Admitidos;
                            cmd.Parameters.Add("@LYD_Admitidos", SqlDbType.VarChar).Value = request.LYD_Admitidos;
                            cmd.Parameters.Add("@Leads_Pend_Pago", SqlDbType.VarChar).Value = request.Leads_Pend_Pago;
                            cmd.Parameters.Add("@LYD_Pend_Pago", SqlDbType.VarChar).Value = request.LYD_Pend_Pago;
                            cmd.Parameters.Add("@Leads_Efectivos", SqlDbType.VarChar).Value = request.Leads_Efectivos;
                            cmd.Parameters.Add("@LYD_Efectivos", SqlDbType.VarChar).Value = request.LYD_Efectivos;
                            cmd.Parameters.Add("@Compromisos", SqlDbType.VarChar).Value = request.Compromisos;
                            cmd.Parameters.Add("@Admitidos_con_Compromiso", SqlDbType.VarChar).Value = request.Admitidos_con_Compromiso;
                            cmd.Parameters.Add("@Admitidos_y_superiores", SqlDbType.VarChar).Value = request.Admitidos_y_superiores;
                            cmd.Parameters.Add("@Mobile_Original", SqlDbType.VarChar).Value = request.Mobile_Original;
                            cmd.Parameters.Add("@Phone_Original", SqlDbType.VarChar).Value = request.Phone_Original;
                            cmd.Parameters.Add("@Count_Matricula_de_Lead_Digital", SqlDbType.VarChar).Value = request.Count_Matricula_de_Lead_Digital;
                            cmd.Parameters.Add("@Count_Matricula_de_Lead_Organico", SqlDbType.VarChar).Value = request.Count_Matricula_de_Lead_Organico;
                            cmd.Parameters.Add("@Count_Matricula_de_Lead_Proveedores", SqlDbType.VarChar).Value = request.Count_Matricula_de_Lead_Proveedores;
                            cmd.Parameters.Add("@Como_se_entero_de_la_ibero", SqlDbType.VarChar).Value = request.Como_se_entero_de_la_ibero;
                            cmd.Parameters.Add("@Sorce_Unificada31", SqlDbType.VarChar).Value = request.Sorce_Unificada31;
                            cmd.Parameters.Add("@Compendio_Motivos_De_No_Interes", SqlDbType.VarChar).Value = request.Compendio_Motivos_De_No_Interes;
                            cmd.Parameters.Add("@Count_Compendio_Motivos_De_No_Interes", SqlDbType.VarChar).Value = request.Count_Compendio_Motivos_De_No_Interes;
                            cmd.Parameters.Add("@Degree_Type_de_Leads", SqlDbType.VarChar).Value = request.Degree_Type_de_Leads;
                            cmd.Parameters.Add("@Count_Reopened", SqlDbType.VarChar).Value = request.Count_Reopened;
                            cmd.Parameters.Add("@FCL", SqlDbType.VarChar).Value = request.FCL;
                            cmd.Parameters.Add("@Reopened_Time", SqlDbType.VarChar).Value = request.Reopened_Time;
                            cmd.Parameters.Add("@Previous_Degree", SqlDbType.VarChar).Value = request.Previous_Degree;
                            cmd.Parameters.Add("@Payment_Mode", SqlDbType.VarChar).Value = request.Payment_Mode;
                            cmd.Parameters.Add("@Count_LYD_Abiertos", SqlDbType.VarChar).Value = request.Count_LYD_Abiertos;
                            cmd.Parameters.Add("@Count_Leads_Abiertos", SqlDbType.VarChar).Value = request.Count_Leads_Abiertos;
                            cmd.Parameters.Add("@Count_LYD_Cerrados", SqlDbType.VarChar).Value = request.Count_LYD_Cerrados;
                            cmd.Parameters.Add("@HubSpotStageStatus", SqlDbType.VarChar).Value = request.HubSpotStageStatus;
                            cmd.Parameters.Add("@HubSpotLeadStatus", SqlDbType.VarChar).Value = request.HubSpotLeadStatus;
                            cmd.Parameters.Add("@Lead_Status", SqlDbType.VarChar).Value = request.Lead_Status;
                            cmd.Parameters.Add("@lifecylestage", SqlDbType.VarChar).Value = request.lifecylestage;
                            cmd.Parameters.Add("@Operacion_Ibero", SqlDbType.VarChar).Value = request.Operacion_Ibero;
                            cmd.Parameters.Add("@TIEMPO_DE_MADURACION", SqlDbType.VarChar).Value = request.TIEMPO_DE_MADURACION;
                            cmd.Parameters.Add("@Date_of_Birth", SqlDbType.VarChar).Value = request.Date_of_Birth;
                            cmd.Parameters.Add("@Cuenta_Tratos_antes_de_Admitidos", SqlDbType.VarChar).Value = request.Cuenta_Tratos_antes_de_Admitidos;
                            cmd.Parameters.Add("@Cuenta_Tratos_en_Admitidos", SqlDbType.VarChar).Value = request.Cuenta_Tratos_en_Admitidos;
                            cmd.Parameters.Add("@Sales_Cycle_Duration", SqlDbType.VarChar).Value = request.Sales_Cycle_Duration;
                            cmd.Parameters.Add("@DM", SqlDbType.VarChar).Value = request.DM;
                            cmd.Parameters.Add("@Fecha_Captacion", SqlDbType.VarChar).Value = request.Fecha_Captacion;
                            cmd.Parameters.Add("@AnoMes_Captacion", SqlDbType.VarChar).Value = request.AnoMes_Captacion;
                            cmd.Parameters.Add("@OPERACION", SqlDbType.VarChar).Value = request.OPERACION;
                            cmd.Parameters.Add("@PRECIO_PROGRAMA", SqlDbType.VarChar).Value = request.PRECIO_PROGRAMA;
                            cmd.Parameters.Add("@IS_RMK", SqlDbType.VarChar).Value = request.IS_RMK;
                            cmd.Parameters.Add("@Metas_Fecha_Inicio_Ingreso", SqlDbType.VarChar).Value = request.Metas_Fecha_Inicio_Ingreso;
                            cmd.Parameters.Add("@Utm_Source", SqlDbType.VarChar).Value = request.Utm_Source == null ? "" : request.Utm_Source;
                            cmd.Parameters.Add("@Utm_Medium", SqlDbType.VarChar).Value = request.Utm_Medium == null ? "" : request.Utm_Medium;
                            cmd.Parameters.Add("@Utm_Content", SqlDbType.VarChar).Value = request.Utm_Content == null ? "" : request.Utm_Content;
                            cmd.Parameters.Add("@Utm_Campaign", SqlDbType.VarChar).Value = request.Utm_Campaign == null ? "" : request.Utm_Campaign;
                            cmd.Parameters.Add("@URL_Visited", SqlDbType.VarChar).Value = request.URL_Visited == null ? "" : request.URL_Visited;
                            cmd.Parameters.Add("@Tipo_Lead_Captacion", SqlDbType.VarChar).Value = request.Tipo_Lead_Captacion == null ? "" : request.Tipo_Lead_Captacion;
                            cmd.Parameters.Add("@ID_supervisor", SqlDbType.VarChar).Value = request.ID_supervisor == null ? "" : request.ID_supervisor;

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
                    throw new DeleteFailureException(nameof(NewZohoLeadsAndDealsQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
