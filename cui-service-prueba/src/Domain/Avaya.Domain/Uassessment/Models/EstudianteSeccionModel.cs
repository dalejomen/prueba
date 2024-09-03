using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class EstudianteSeccionModel
    {       
        public int Id { get; set; }
        public string id_periodo_academico { get; set; }
        public string id_seccion { get; set; }
        public string codigo_grupo { get; set; }
        public string id_estudiante { get; set; }
        public string id_plan_estudio { get; set; }

    }


}
