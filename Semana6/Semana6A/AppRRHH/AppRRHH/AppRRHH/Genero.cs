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
    public class Genero
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int GeneroId { get; set; }

        [Column]
        public string DescripcionGenero { get; set; }
    }
}
