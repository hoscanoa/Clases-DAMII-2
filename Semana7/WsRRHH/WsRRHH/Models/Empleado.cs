using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WsRRHH.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string nombre { get; set; }
        public string DNI { get; set; }
        public string Ubicacion { get; set; }
        public string Direccion { get; set; }
        public string Genero { get; set; }
        public DateTime FecNac { get; set; }
    }
}