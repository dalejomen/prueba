using AutoMapper;
using Ibero.Services.Avaya.Domain.Banner.Models;
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

namespace Ibero.Services.Avaya.Domain.Banner.Queries
{
    public class GetStatusGradePersonQuery : IRequest<object>
    {
        public string id_banner { get; set; }

        public string codProgram { get; set; }
        public string Program { get; set; }
        public class Handler : IRequestHandler<GetStatusGradePersonQuery, object>
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("Banner");
            }
            public async Task<object> Handle(GetStatusGradePersonQuery request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_VALIDATEGRADE", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@JsonData", SqlDbType.VarChar).Value = JsonRequest;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    infoDB = sqlReader[0].ToString();
                                }
                            }
                        }
                    }
                    response = infoDB;
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetStatusGradePersonQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
