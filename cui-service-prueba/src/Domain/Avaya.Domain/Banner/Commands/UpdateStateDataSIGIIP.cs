using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ibero.Services.Avaya.Domain.Banner.Commands
{
    public class UpdateStateDataSIGIIP : IRequest<object>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<UpdateStateDataSIGIIP, object>
        {
            private readonly string _connection;

            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("Banner");
            }
            public async Task<object> Handle(UpdateStateDataSIGIIP request, CancellationToken cancellationToken)
            {
                object result = new object();

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_SIGIIP", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 3;
                            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = request.Id;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    var infoDB = new
                                    {
                                        result = sqlReader[0].ToString(),
                                        message = "Success"
                                    };
                                    result = infoDB;
                                }
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    var response = new
                    {
                        result = false,
                        message = e.ToString()
                    };

                    result = response;
                }
                return result;
            }
        }
    }
}
