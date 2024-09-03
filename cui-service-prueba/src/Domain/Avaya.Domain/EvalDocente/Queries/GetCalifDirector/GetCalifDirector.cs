using AutoMapper;
using Ibero.Services.Avaya.Domain.EvalDocente.Model;
using Ibero.Services.Avaya.Domain.Exceptions;
using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ibero.Services.Avaya.Domain.EvalDocente.Queries.GetCalifDirector
{
    public class GetCalifDirector : IRequest<object>
    {
        public int idBanner { get; set; }
        public int periodo { get; set; }
        public string programa { get; set; }
        public class Handler : IRequestHandler<GetCalifDirector, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;

            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("Banner");
            }

            public async Task<object> Handle(GetCalifDirector request, CancellationToken cancellationToken)
            {
                var responses = new List<CalifDirectorModel>();
                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("[SP_DOCENTECALIF]", sql))
                        {
                            //Parametros
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@reference", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@idBannerDocente", SqlDbType.Int).Value = request.idBanner;
                            cmd.Parameters.Add("@periodo", SqlDbType.Int).Value = request.periodo;
                            cmd.Parameters.Add("@Programa", SqlDbType.VarChar).Value = request.programa;

                            await sql.OpenAsync();
                            //Ciclo de lectura de tabla
                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    CalifDirectorModel data = new CalifDirectorModel();

                                    data.idBannerDocente = sqlReader.GetString(0);
                                    data.periodo = sqlReader.GetString(1);
                                    data.codigoPrograma = sqlReader.GetString(2);
                                    data.materia = sqlReader.GetString(3);
                                    data.ncr = sqlReader.GetString(4);
                                    data.calfEst = sqlReader.GetString(5);
                                    data.PromRespuesta = sqlReader.GetString(6);
                                    responses.Add(data);
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(GetCalifDirector), request, ex.Message);
                }
                return responses;
            }
        }
    }
}
