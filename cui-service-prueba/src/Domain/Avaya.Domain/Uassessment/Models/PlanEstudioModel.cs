using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class PlanEstudioModel
    {       
        public int Id { get; set; }
        public string id_plan_estudio { get; set; }
        public string codigo_plan_estudio { get; set; }
        public string nombre_plan_estudio { get; set; }
        public string id_carrera { get; set; }
        public string id_modalidad { get; set; }
        public string nombre_modalidad { get; set; }
        public string anio_plan_estudio { get; set; }
        public int numero_creditos_plan_estudio { get; set; }
        public int numero_creditos_periodo { get; set; }
        public string codigo_tipo_periodo_academico { get; set; }
        public string vigencia_fecha_ini { get; set; }
        public string vigencia_fecha_fin { get; set; }
        public string numero_minimo_anios { get; set; }
        public string perfil_ingreso { get; set; }
        public string perfil_egreso { get; set; }
        public string codigo_version_plan_estudio_actual { get; set; }
        public string codigo_version_plan_estudio_anterior { get; set; }
        public int indicador_version_actual { get; set; }

    }


}
