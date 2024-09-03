using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class PeriodoacademicoModel
    {
        public int Id { get; set; }
        public string id_periodo_academico { get; set; }
        public string codigo_periodo_academico { get; set; }
        public string nombre_periodo_academico { get; set; }
        public string codigo_tipo_periodo_academico { get; set; }
        public string nombre_tipo_periodo_academico { get; set; }
        public string agno_periodo_academico { get; set; }
        public int numero_semanas { get; set; }
        public string fecha_inicio_periodo { get; set; }
        public string fecha_fin_periodo { get; set; }
        public string indicador_actual { get; set; }
        public string indicador_programable { get; set; }

    }

   
}
