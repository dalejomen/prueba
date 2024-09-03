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
    public class NewZohoTbl_ClientesQuery : IRequest<object>
    {

        public string Concat_Nombre { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Identification_Number { get; set; }
        public string Primary_Email { get; set; }
        public string Mobile { get; set; }

        public class Handler : IRequestHandler<NewZohoTbl_ClientesQuery, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;


            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("DWHIbero");
            }
            public async Task<object> Handle(NewZohoTbl_ClientesQuery request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("ZOHO_SP_Intert_update_ZohoTbl_Clientes", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@Concat_Nombre", SqlDbType.VarChar).Value = request.Concat_Nombre;
                            cmd.Parameters.Add("@Nombre_Cliente", SqlDbType.VarChar).Value = request.Nombre_Cliente;
                            cmd.Parameters.Add("@Identification_Number", SqlDbType.VarChar).Value = request.Identification_Number;
                            cmd.Parameters.Add("@Primary_Email", SqlDbType.VarChar).Value = request.Primary_Email;
                            cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = request.Mobile;
                            
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
