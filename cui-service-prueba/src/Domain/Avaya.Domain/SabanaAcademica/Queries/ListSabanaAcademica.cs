using AutoMapper;
using Ibero.Services.Avaya.Domain.Exceptions;
using Ibero.Services.Avaya.Domain.Infrastructure.Abstract;
using Ibero.Services.Avaya.Domain.SabanaAcademica.Model;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ibero.Services.Avaya.Domain.SabanaAcademica.Queries
{
    public class ListSabanaAcademica : IRequest<object>
    {
        public class Handler : IRequestHandler<ListSabanaAcademica, object>
        {
            // variables Contexto
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;
            // constructor Context
            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("Banner");

            }

            public async Task<object> Handle(ListSabanaAcademica request, CancellationToken cancellationToken)
            {
                var responses = new List<SabanaAcademicaModel>();

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_SABANA", sql))
                        {
                            //Parametros
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@reference", SqlDbType.Int).Value = 1;

                            await sql.OpenAsync();
                            //Ciclo de lectura de tabla
                            using (var sqlReader = await cmd.ExecuteReaderAsync())
                            {
                                while (await sqlReader.ReadAsync())
                                {
                                    SabanaAcademicaModel data = new SabanaAcademicaModel();

                                    data.periodoCursado = sqlReader.GetString(0);
                                    data.nombreCurso = sqlReader.GetString(1);
                                    data.codigoMateria = sqlReader.GetString(2);
                                    data.creditosMateria = sqlReader.GetDecimal(3);
                                    data.totalCreditosSemestre = sqlReader.GetString(4);
                                    data.minimoAprobatorio = sqlReader.GetDecimal(5);
                                    data.tipoMateriaPrograma = sqlReader.GetString(6);
                                    data.codigoPrograma = sqlReader.GetString(7);
                                    data.totalCreditoPrograma = sqlReader.GetDecimal(8);
                                    data.nombrePrograma = sqlReader.GetString(9);
                                    responses.Add(data);
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(ListSabanaAcademica), request, ex.Message);
                }

                return responses;
            }

        }
    }
}
