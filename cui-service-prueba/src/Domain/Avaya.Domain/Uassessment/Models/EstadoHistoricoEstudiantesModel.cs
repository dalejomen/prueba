using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class EstadoHistoricoEstudiantesModel
    {       
        public int Id { get; set; } 
        public string id_estudiante { get; set; }
        public string id_campus { get; set; }
        public string id_periodo_academico { get; set; }
        public string id_jornada { get; set; }
        public string id_plan_estudio { get; set; }
        public string id_especialidad { get; set; }
        public string indicador_estado { get; set; }

    }


}
