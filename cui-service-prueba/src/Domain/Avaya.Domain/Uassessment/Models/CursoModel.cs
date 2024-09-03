using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class CursoModel
    {       
        public int Id { get; set; }
        public string id_curso { get; set; }
        public string codigo_curso { get; set; }
        public string nombre_curso { get; set; }
        public string id_departamento { get; set; }
        public string id_nivel_curso { get; set; }
        public int numero_creditos { get; set; }
        public string codigo_version_curso_actual { get; set; }
        public string codigo_version_curso_anterior { get; set; }
        public int indicador_version_actual { get; set; }

    }


}
