namespace Ibero.Services.Avaya.Domain.ZohoCrmDwh.Commands
{
    using AutoMapper;
    using Ibero.Services.Avaya.Domain.Exceptions;
    using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
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

    public class ZohoEncuestaImport : IRequest<object>
    {
        public int reference { get; set; }
        public string IDAGENTE { get; set; }
        public string Skill { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Supervisor { get; set; }
        public string Nombre_Supervisor { get; set; }
        public string Autor { get; set; }
        public string Identification { get; set; }
        public string Tartamiento { get; set; }
        public string Fecha { get; set; }
        public string Codigo { get; set; }
        public int Respuesta1 { get; set; }
        public int Respuesta2 { get; set; }
        public int RespuestaUno { get; set; }
        public int RespuestaDos { get; set; }
        public string SupervisorGivenName { get; set; }
        public string Nombre_Asesor { get; set; }
        public string Clasificacion_1 { get; set; }
        public string Clasificacion_2 { get; set; }
        public class Handler : IRequestHandler<ZohoEncuestaImport, object>
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
            public async Task<object> Handle(ZohoEncuestaImport request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";
                string jsonString = JsonConvert.SerializeObject(request); ;

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ZohoEncuestaServicio", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@JsonData", SqlDbType.VarChar).Value = jsonString;

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
                    throw new DeleteFailureException(nameof(ZohoEncuestaImport), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
