using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class AdministrativoModel
    {       
        public int Id { get; set; }
        public string id_administrativo { get; set; }
        public string codigo_administrativo { get; set; }
        public string username { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string correo_electronico_administrativo { get; set; }
        public string id_departamento { get; set; }
    }


}
