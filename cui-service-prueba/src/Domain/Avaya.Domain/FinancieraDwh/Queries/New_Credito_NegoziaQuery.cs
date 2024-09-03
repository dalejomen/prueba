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

namespace Ibero.Services.Avaya.Domain.FinancieraDwh.Queries
{
    public class New_Credito_NegoziaQuery : IRequest<object>
    {        
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public string DIRECCION_ELECTRONICA { get; set; }
        public string TELEFONO { get; set; }
        public string MOVIL { get; set; }
        public string IDENTIFICACION { get; set; }
        public string TIPO_IDENTIFICACION { get; set; }
        public string CIUDAD { get; set; }
        public string ORDEN { get; set; }
        public string DOCUMENTO_ORDEN { get; set; }
        public string VALOR_CREDITO { get; set; }
        public string CUOTAS { get; set; }
        public string VALORCUOTA { get; set; }
        public string PERIODO { get; set; }
        public string NUMERO_FILA { get; set; }
        public string CODIGO_PROGRAMA { get; set; }
        public string PROGRAMA { get; set; }
        public string TRANSACTION_ID { get; set; }
        public string IDBANNER { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }
        public string SCORING { get; set; }
        public string FECHAPAGOESCOGIDA { get; set; }

        public class Handler : IRequestHandler<New_Credito_NegoziaQuery, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;

            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("FinancieraDb");
            }
            public async Task<object> Handle(New_Credito_NegoziaQuery request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("IBEP_SP_CREDITO_NEGOZIA", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@PRIMER_NOMBRE", SqlDbType.VarChar).Value = request.PRIMER_NOMBRE;
                            cmd.Parameters.Add("@SEGUNDO_NOMBRE", SqlDbType.VarChar).Value = request.SEGUNDO_NOMBRE;
                            cmd.Parameters.Add("@PRIMER_APELLIDO", SqlDbType.VarChar).Value = request.PRIMER_APELLIDO;
                            cmd.Parameters.Add("@SEGUNDO_APELLIDO", SqlDbType.VarChar).Value = request.SEGUNDO_APELLIDO;
                            cmd.Parameters.Add("@DIRECCION_ELECTRONICA", SqlDbType.VarChar).Value = request.DIRECCION_ELECTRONICA;
                            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = request.TELEFONO;
                            cmd.Parameters.Add("@MOVIL", SqlDbType.VarChar).Value = request.MOVIL;
                            cmd.Parameters.Add("@IDENTIFICACION", SqlDbType.VarChar).Value = request.IDENTIFICACION;
                            cmd.Parameters.Add("@TIPO_IDENTIFICACION", SqlDbType.VarChar).Value = request.TIPO_IDENTIFICACION;
                            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = request.CIUDAD;
                            cmd.Parameters.Add("@ORDEN", SqlDbType.VarChar).Value = request.ORDEN;
                            cmd.Parameters.Add("@DOCUMENTO_ORDEN", SqlDbType.VarChar).Value = request.DOCUMENTO_ORDEN;
                            cmd.Parameters.Add("@VALOR_CREDITO", SqlDbType.VarChar).Value = request.VALOR_CREDITO;
                            cmd.Parameters.Add("@CUOTAS", SqlDbType.VarChar).Value = request.CUOTAS;
                            cmd.Parameters.Add("@VALORCUOTA", SqlDbType.VarChar).Value = request.VALORCUOTA;
                            cmd.Parameters.Add("@PERIODO", SqlDbType.VarChar).Value = request.PERIODO;
                            cmd.Parameters.Add("@NUMERO_FILA", SqlDbType.VarChar).Value = request.NUMERO_FILA;
                            cmd.Parameters.Add("@CODIGO_PROGRAMA", SqlDbType.VarChar).Value = request.CODIGO_PROGRAMA;
                            cmd.Parameters.Add("@PROGRAMA", SqlDbType.VarChar).Value = request.PROGRAMA;
                            cmd.Parameters.Add("@TRANSACTIOM_ID", SqlDbType.VarChar).Value = request.TRANSACTION_ID;
                            cmd.Parameters.Add("@IDBANNER", SqlDbType.VarChar).Value = request.IDBANNER;
                            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = request.DESCRIPCION;
                            cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = request.ESTADO;
                            cmd.Parameters.Add("@SCORING", SqlDbType.VarChar).Value = request.SCORING;
                            cmd.Parameters.Add("@FECHAPAGOESCOGIDA", SqlDbType.VarChar).Value = request.FECHAPAGOESCOGIDA;

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
                    throw new DeleteFailureException(nameof(New_Credito_NegoziaQuery), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
