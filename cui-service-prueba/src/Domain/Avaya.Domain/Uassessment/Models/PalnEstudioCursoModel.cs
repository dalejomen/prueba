using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class PalnEstudioCursoModel
    {       
        public int Id { get; set; }
        public string id_plan { get; set; }
        public string id_curso { get; set; }
        public string numero_nivel { get; set; }
        public string prerrequisitos_curso { get; set; }
        public string correquisitos_curso { get; set; }
        public string equivalencias_curso { get; set; }

    }


}
