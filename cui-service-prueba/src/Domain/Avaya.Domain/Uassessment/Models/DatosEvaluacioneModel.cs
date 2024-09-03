using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class DatosEvaluacioneModel
    {       
        public int Id { get; set; }
        public string id_estudiante { get; set; }
        public string id_campus { get; set; }
        public string id_periodo_academico { get; set; }
        public string id_jornada { get; set; }
        public string id_seccion { get; set; }
        public string nm_nota_obtenida { get; set; }
        public string nm_nota_obtenida_porcentual { get; set; }
        public string id_calificacion { get; set; }
    }


}
