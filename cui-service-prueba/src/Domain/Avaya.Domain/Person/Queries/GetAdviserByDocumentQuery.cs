namespace Ibero.Services.Avaya.Domain.Person.Queries
{
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
    using Ibero.Services.Avaya.Domain.Person.Models;


    public class GetAdviserByDocumentQuery : IRequest<object>
    {
        public string Document { get; set; }

        public class Handler : IRequestHandler<GetAdviserByDocumentQuery, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;

            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("AvayaMainDb");
            }
            public async Task<object> Handle(GetAdviserByDocumentQuery request, CancellationToken cancellationToken)
            {
                var response = new List<AsesorModel>();
                var infoDB = "";
                try
                {                   
                    AsesorModel dataper = new AsesorModel();

                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("AVAS_SP_SEARCH_ADVISER_CASE", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Document", SqlDbType.VarChar).Value = request.Document;

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
                    throw new DeleteFailureException(nameof(GetAdviserByDocumentQuery), ex.Message, ex.Message);
                }
                return infoDB;
            }
        }
    }
}
