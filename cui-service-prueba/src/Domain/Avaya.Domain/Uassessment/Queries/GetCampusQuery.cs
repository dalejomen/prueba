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
    public class GetCampusQuery : IRequest<object>
    {
        public string Nombre { get; set; }
        public class Handler : IRequestHandler<GetCampusQuery, object> 
        {
            private readonly string _connection;


            public Handler(IConfiguration configuration)
            {
                _connection = configuration.GetConnectionString("UASSESSMENT");
            }
            public async Task<object> Handle(GetCampusQuery request, CancellationToken cancellationToken)
            {
                var response = new List<CampusModel>();
                var JsonRequest = JsonConvert.SerializeObject(request);
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CAMPUS", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = request.Nombre;
                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    CampusModel model = new CampusModel();
                                    model.Id_campus = sqlReader.GetString(0);
                                    model.Codigo_campus = sqlReader.GetString(1);
                                    model.Nombre_campus = sqlReader.GetString(2);
                                    model.Id_institucion = sqlReader.GetString(3);
                                    response.Add(model);
                                }
                            }                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetCampusQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
