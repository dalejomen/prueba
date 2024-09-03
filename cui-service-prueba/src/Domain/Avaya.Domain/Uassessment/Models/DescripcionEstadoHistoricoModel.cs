using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Uassessment.Models
{
    public class DescripcionEstadoHistoricoModel
    {       
        public int Id { get; set; }
        public string id_estado { get; set; }
        public string nombre_indicador_estado { get; set; }
        public string descripcion_estado_historico { get; set; }

    }


}
