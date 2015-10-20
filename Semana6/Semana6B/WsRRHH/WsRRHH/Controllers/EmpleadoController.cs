using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WsRRHH.Models;

namespace WsRRHH.Controllers
{
    public class EmpleadoController : ApiController
    {
        MyDataContext db = new MyDataContext();
        // GET api/empleado
        public IEnumerable<Empleado> Get()
        {
            return db.listaEmpleado.ToList();
        }

        // GET api/empleado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/empleado
        public void Post([FromBody]Empleado value)
        {
            db.listaEmpleado.Add(value);
            db.SaveChanges();

        }

        // PUT api/empleado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/empleado/5
        public void Delete(int id)
        {
        }
    }
}
