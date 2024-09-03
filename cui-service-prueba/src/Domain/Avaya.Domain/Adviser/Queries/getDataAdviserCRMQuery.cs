using System;
using System.Collections.Generic;
using System.Text;
using Ibero.Services.Avaya.Domain.Exceptions;
using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ibero.Services.Avaya.Domain.Adviser.Models;

namespace Ibero.Services.Avaya.Domain.Adviser.Query
{
    public class getDataAdviserCRMQuery : IRequest<object>
    {
        public int Reference { get; set; }
        public class Handler : IRequestHandler<getDataAdviserCRMQuery, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;

            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("Adviser");
            }
            public async Task<object> Handle(getDataAdviserCRMQuery request, CancellationToken cancellationToken)
            {
                var response = new List<AdviserCRMModel>();
                var infoDB = "";
                try
                {
                    AdviserCRMModel dataper = new AdviserCRMModel();

                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ADVISER_CRM", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Reference", SqlDbType.Int).Value = request.Reference;

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
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(getDataAdviserCRMQuery), ex.Message, ex.Message);
                }
                return infoDB;
            }
        }
    }
}
