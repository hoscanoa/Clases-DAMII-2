using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WsRRHH.Models
{
    public class MyDataContext:DbContext
    {
        public DbSet<Empleado> listaEmpleado { get; set; }
    }
}