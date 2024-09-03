using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class DescripcionEstadoInscripcionModel
    {       
        public int Id { get; set; }
        public string id_estado_inscripcion { get; set; }
        public string codigo_estado_inscripcion { get; set; }
        public string nombre_estado_inscripcion { get; set; }
        public string descripcion_estado_inscripcion { get; set; }
        public string indicador_aprobado { get; set; }
        public string numero_prioridad { get; set; }

    }


}
