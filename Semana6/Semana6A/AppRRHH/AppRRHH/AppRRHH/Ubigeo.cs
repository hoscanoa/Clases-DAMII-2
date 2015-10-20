using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AppRRHH
{
    [Table]
    public class Ubigeo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int UbigeoId { get; set; }

        [Column]
        public string DescripcionUbigeo { get; set; }
    }
}
