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

    public class ZohoEncuestaSatisfacion : IRequest<object>
    {
        public int reference { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Identification_Number { get; set; }
        public string Banner_Student_ID { get; set; }
        public string Type { get; set; }
        public string Case_Reason { get; set; }
        public string Faculty { get; set; }
        public string Degree { get; set; }
        public string Degree_Type_Name { get; set; }
        public string Created_Time { get; set; }
        public string Pregunta1 { get; set; }
        public string Pregunta2 { get; set; }
        public string Pregunta3 { get; set; }
        public string Fecha { get; set; }
        public class Handler : IRequestHandler<ZohoEncuestaSatisfacion, object>
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
            public async Task<object> Handle(ZohoEncuestaSatisfacion request, CancellationToken cancellationToken)
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
