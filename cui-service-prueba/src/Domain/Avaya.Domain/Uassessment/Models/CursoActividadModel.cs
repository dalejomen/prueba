using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class CursoActividadModel
    {       
        public int Id { get; set; }
        public string id_curso { get; set; }
        public string id_actividad { get; set; }
        public string codigo_actividad { get; set; }
        public string nombre_actividad { get; set; }
        public string numero_bloques_semana { get; set; }
        public string id_modalidad { get; set; }
        public string codigo_modalidad { get; set; }
        public string nombre_modalidad { get; set; }
        public string numero_horas_semanales { get; set; }
        public string numero_horas_consecutivas { get; set; }

    }


}
