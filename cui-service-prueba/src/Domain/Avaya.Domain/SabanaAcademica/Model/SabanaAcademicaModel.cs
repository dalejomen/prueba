using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.SabanaAcademica.Model
{
    public class SabanaAcademicaModel
    {
        public string periodoCursado { get; set; }
        public string nombreCurso { get; set; }
        public string codigoMateria { get; set; }
        public decimal creditosMateria { get; set; }
        public string totalCreditosSemestre { get; set; }
        public decimal minimoAprobatorio { get; set; }
        public string tipoMateriaPrograma { get; set; }
        public string codigoPrograma { get; set; }
        public decimal totalCreditoPrograma { get; set; }
        public string nombrePrograma { get; set; }
    }
}
