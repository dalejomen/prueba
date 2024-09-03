using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class DatosInscripcionesModel
    {       
        public int Id { get; set; }
        public string id_estudiante { get; set; }
        public string id_campus { get; set; }
        public string id_periodo_academico { get; set; }
        public string id_jornada { get; set; }
        public string id_curso_inscrito { get; set; }
        public string id_estado_inscripcion { get; set; }
        public string nota_final { get; set; }
        public string nota_final_porcentual { get; set; }


    }


}
