using System;
using System.Collections.Generic;
using System.Text;

namespace Ibero.Services.Avaya.Domain.Banner.Models
{
    public class SIGIIPModel
    {
        public int Id { get; set; }
        public string Id_Banner { get; set; }
        public string Apellidos { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Identifiacion { get; set; }
        public string Tipo_Documento { get; set; }
        public int Codigo_Ciudad { get; set; }
        public string Nombre_Ciudad { get; set; }
        public int Codigo_Departamento { get; set; }
        public string Nombre_Departamento { get; set; }
        public string Codigo_Pais { get; set; }
        public string Nombre_Pais { get; set; }
        public string Email_Institucional { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Genero { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string Periodo { get; set; }
        public string Codigo_Programa { get; set; }
        public string Programa { get; set; }
        public string Facultad { get; set; }
        public string Nivel { get; set; }
        public string Modalidad { get; set; }
    }
}
