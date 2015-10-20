using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AppRRHH
{
    public class MyDataContext:DataContext
    {
        public static string cadenaConexion = "Data Source=isostore:/RRHH.sdf";
        public Table<Genero> ListaGeneros;
        public Table<Ubigeo> ListaUbigeos;

        public MyDataContext(string cadenaConexion):
            base(cadenaConexion)
        {
        }
    }
}
