namespace Ibero.Services.Avaya.Domain.Infrastructure.Abstract
{
    using Ibero.Services.Avaya.Domain.Exceptions;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class IInternalService
    {
        private readonly string _connection;

        public IInternalService(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("UtilitaryDb");
        }

        public string getHomologationID(string TableReference, string IdReference, string HomReference, int CodeReference)
        {
            var response = "";
            try
            {
                using (SqlConnection sql = new SqlConnection(_connection))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT " + HomReference + " FROM " + TableReference + " WHERE " + IdReference + " = " + CodeReference + ";", sql))
                    {
                        cmd.CommandType = CommandType.Text;
                        sql.Open();

                        using (var sqlReader = cmd.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                response += sqlReader[0].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.InsErrorLog(this.GetType().FullName, "SELECT " + HomReference + " FROM " + TableReference + " WHERE " + IdReference + " = " + CodeReference + ";", ex.StackTrace, ex.Message);
                response = CodeReference.ToString();
            }
            return response;
        }

        public void InsErrorLog(string Method, string Request, string Response, string Message)
        {
            try
            {
                /*
                string IP = System.Net.Dns.GetHostName() + " - " + System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[2].ToString();
                */
                using (SqlConnection sql = new SqlConnection(_connection))
                {

                    using (SqlCommand cmd = new SqlCommand("IBEP_InsErrorLog", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Method", SqlDbType.VarChar).Value = Method;
                        cmd.Parameters.Add("@Request", SqlDbType.VarChar).Value = Request;
                        cmd.Parameters.Add("@Response", SqlDbType.VarChar).Value = Response;
                        cmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = Message;
                        cmd.Parameters.Add("@IP", SqlDbType.VarChar).Value = "NA";//IP;

                        sql.Open();
                        cmd.ExecuteNonQuery();
                    }

                }

            }
            catch (Exception ex)
            {
                throw new DeleteFailureException(nameof(IInternalService), ex.Message, ex.Message);
            }
            return;
        }
    }
}