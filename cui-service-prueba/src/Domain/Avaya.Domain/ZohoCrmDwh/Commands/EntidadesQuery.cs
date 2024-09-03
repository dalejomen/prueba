namespace Ibero.Services.Avaya.Domain.ZohoCrmDwh.Commands
{
    using AutoMapper;
    using Ibero.Services.Avaya.Domain.Exceptions;
    using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
    using Ibero.Services.Avaya.Domain.ZohoCrmDwh.Model;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class EntidadesQuery : IRequest<object>
    {
        public string ID { get; set; }

        public string Nombre { get; set; }

        public class Handler : IRequestHandler<EntidadesQuery, object>
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
            public async Task<object> Handle(EntidadesQuery request, CancellationToken cancellationToken)
            {
                var response = new List<Entidad>();

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_Entidades", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            //Definir filtros
                            //cmd.Parameters.Add("@fechaInicial", SqlDbType.VarChar).Value = request.fecha_1;
                            //cmd.Parameters.Add("@fechaFinal", SqlDbType.VarChar).Value = request.fecha_2;

                            await sql.OpenAsync();

                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    Entidad dataper = new Entidad();
                                    dataper.ID = sqlReader.GetValue(0).ToString();
                                    dataper.Nombre = sqlReader.GetValue(1).ToString();
                                    response.Add(dataper);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(EntidadesQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
