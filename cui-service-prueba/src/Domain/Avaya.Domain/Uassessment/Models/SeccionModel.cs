using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class SeccionModel
    {       
        public int Id { get; set; }
        public string id_campus { get; set; }
        public string id_periodo_academico { get; set; }
        public string id_jornada { get; set; }
        public string id_seccion { get; set; }
        public string codigo_seccion { get; set; }
        public string nombre_seccion { get; set; }
        public string codigo_grupo { get; set; }
        public string nro_inscritos { get; set; }
        public string id_lista_cruzada { get; set; }
        public string indicador_curso_principal { get; set; }
        public string id_curso { get; set; }
        public string nombre_curso { get; set; }
        public string id_actividad { get; set; }
        public string nombre_actividad { get; set; }
        public string id_liga { get; set; }
        public string indicador_seccion_padre { get; set; }
        public string id_modalidad { get; set; }
        public string nombre_modalidad { get; set; }
        public string id_idioma { get; set; }
        public string nombre_idioma { get; set; }

    }


}
