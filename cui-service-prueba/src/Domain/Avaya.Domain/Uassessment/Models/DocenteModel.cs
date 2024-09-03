using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class DocenteModel
    {       
        public int Id { get; set; }
        public string id_docente { get; set; }
        public string codigo_docente { get; set; }
        public string username { get; set; }
        public string nombres_docente { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string correo_electronico_docente { get; set; }
        public string telefono_docente { get; set; }
        public string extension_telefono_docente { get; set; }

    }


}
