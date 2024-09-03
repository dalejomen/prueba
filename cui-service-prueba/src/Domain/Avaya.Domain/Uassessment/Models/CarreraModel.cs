using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class CarreraModel
    {       
        public int Id { get; set; }
        public string id_carrera { get; set; }
        public string codigo_carrera { get; set; }
        public string nombre_carrera { get; set; }
        public string id_facultad { get; set; }
        public string id_tipo_carrera { get; set; }
        public string codigo_tipo_carrera { get; set; }
        public string nombre_tipo_carrera { get; set; }
    }

   
}
