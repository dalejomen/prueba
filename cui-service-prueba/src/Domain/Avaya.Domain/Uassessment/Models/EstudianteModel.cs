using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class EstudianteModel
    {       
        public int Id { get; set; }
        public string id_estudiante { get; set; }
        public string codigo_estudiante { get; set; }
        public string username { get; set; }
        public string nombres_estudiante { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string telefono_estudiante { get; set; }
        public string correo_electronico_estudiante { get; set; }
        public string direccion_estudiante { get; set; }


    }


}
