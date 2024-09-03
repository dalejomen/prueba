using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class SeccionComponeteEvaluacionModel
    {       
        public int Id { get; set; }
        public string id_periodo_academico { get; set; }
        public string id_seccion { get; set; }
        public string id_calificacion_padre { get; set; }
        public string id_calificacion { get; set; }
        public string codigo_calificacion { get; set; }
        public string nombre_calificacion { get; set; }
        public string indicador_calculada { get; set; }
        public string formula { get; set; }
        public string porcentaje { get; set; }
        public string orden_prueba { get; set; }

    }


}
