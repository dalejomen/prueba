namespace Ibero.Services.Avaya.Domain.Avaya.Commands
{

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

    public class New_LeadsCommands : IRequest<object>
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string correo { get; set; }
        public string movil { get; set; }
        public string telefono { get; set; }
        public string descripcion { get; set; }
        public string tiempo_contacto { get; set; }
        public string id_leads { get; set; }
        public string carrera_interes { get; set; }
        public string leads_agente_id { get; set; }
        public string fecha { get; set; }
        public string PropietarioPosibleCliente { get; set; }
        public string FechaModificacion { get; set; }
        public string TipoCarrera { get; set; }
        public string CodigoCarrera { get; set; }
        public string IdPropietario { get; set; }
        public string ExtPropietario { get; set; }

        public class Handler : IRequestHandler<New_LeadsCommands, object>
        {
            private readonly IAvayaDbContext context;
            private readonly IMapper mapper;
            private readonly string _connection;
            

            public Handler(IAvayaDbContext context, IMapper mapper, IConfiguration configuration)
            {
                this.context = context;
                this.mapper = mapper;
                _connection = configuration.GetConnectionString("AvayaDb");
            }
            public async Task<object> Handle(New_LeadsCommands request, CancellationToken cancellationToken)
            {
                var response = new object();
                var infoDB = "";

                try
                {
                    using (SqlConnection sql = new SqlConnection(_connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("IBEP_SP_New_Leads", sql))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = request.nombre.ToString();
                            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = request.apellido.ToString();
                            cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = request.ciudad.ToString();
                            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = request.correo.ToString();
                            cmd.Parameters.Add("@movil", SqlDbType.VarChar).Value = request.movil.ToString();
                            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = request.telefono.ToString();
                            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = request.descripcion.ToString();
                            cmd.Parameters.Add("@tiempo_contacto", SqlDbType.VarChar).Value = request.tiempo_contacto.ToString();
                            cmd.Parameters.Add("@id_leads", SqlDbType.VarChar).Value = request.id_leads.ToString();
                            cmd.Parameters.Add("@carrera_interes", SqlDbType.VarChar).Value = request.carrera_interes.ToString();
                            cmd.Parameters.Add("@leads_agente_id", SqlDbType.VarChar).Value = request.leads_agente_id.ToString();
                            cmd.Parameters.Add("@propietariopleads", SqlDbType.VarChar).Value = request.PropietarioPosibleCliente.ToString();
                            cmd.Parameters.Add("@fecha_modificacion", SqlDbType.VarChar).Value = request.FechaModificacion.ToString();
                            cmd.Parameters.Add("@tipo_carrera", SqlDbType.VarChar).Value = request.TipoCarrera.ToString();
                            cmd.Parameters.Add("@codigo_carrera", SqlDbType.VarChar).Value = request.CodigoCarrera.ToString();
                            cmd.Parameters.Add("@id_propietario", SqlDbType.VarChar).Value = request.IdPropietario.ToString();
                            cmd.Parameters.Add("@ext_propietario", SqlDbType.VarChar).Value = request.ExtPropietario.ToString();

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
                    throw new DeleteFailureException(nameof(New_LeadsCommands), ex.Message, ex.Message);
                }
                return response;
            }
        }
    }
}
