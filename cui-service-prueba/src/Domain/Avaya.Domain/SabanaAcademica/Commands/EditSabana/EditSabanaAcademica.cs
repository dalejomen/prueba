using AutoMapper;
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

namespace Ibero.Services.Avaya.Domain.SabanaAcademica.Commands.EditSabana
{
    public class EditSabanaAcademica : IRequest<object>
    {
        public string periodoCursado { get; set; }
        public string nombreCurso { get; set; }
        public string codigoMateria { get; set; }
        public decimal creditosMateria { get; set; }
        public string totalCreditosSemestre { get; set; }
        public decimal minimoAprobatorio { get; set; }
        public string tipoMateriaPrograma { get; set; }
        public string codigoPrograma { get; set; }
        public decimal totalCreditoPrograma { get; set; }
        public string nombrePrograma { get; set; }

        public class Handler : IRequestHandler<EditSabanaAcademica, object>
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

            public async Task<object> Handle(EditSabanaAcademica request, CancellationToken cancellationToken)
            {

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_SABANA", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@reference", SqlDbType.Int).Value = 3;
                            cmd.Parameters.Add("@periodoCursado", SqlDbType.NChar).Value = request.periodoCursado;
                            cmd.Parameters.Add("@nombreCurso", SqlDbType.NVarChar).Value = request.nombreCurso;
                            cmd.Parameters.Add("@codigoMateria", SqlDbType.NVarChar).Value = request.codigoMateria;
                            cmd.Parameters.Add("@creditosMateria", SqlDbType.Decimal).Value = request.creditosMateria;
                            cmd.Parameters.Add("@totalCreditosSemestre", SqlDbType.NVarChar).Value = request.totalCreditosSemestre;
                            cmd.Parameters.Add("@minimoAprobatorio", SqlDbType.Decimal).Value = request.minimoAprobatorio;
                            cmd.Parameters.Add("@tipoMateriaPrograma", SqlDbType.NChar).Value = request.tipoMateriaPrograma;
                            cmd.Parameters.Add("@codigoPrograma", SqlDbType.NChar).Value = request.codigoPrograma;
                            cmd.Parameters.Add("@totalCreditoPrograma", SqlDbType.NChar).Value = request.totalCreditoPrograma;
                            cmd.Parameters.Add("@nombrePrograma", SqlDbType.NChar).Value = request.nombrePrograma;

                            await sql.OpenAsync();
                            var sqlReader = await cmd.ExecuteReaderAsync();
                            await sqlReader.ReadAsync();
                        }
                        return Unit.Value;
                    }
                }
                catch (Exception ex)
                {
                    throw new DeleteFailureException(nameof(EditSabanaAcademica), ex.Message, ex.Message);
                }
            }

        }
    }
}
