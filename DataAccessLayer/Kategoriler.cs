using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Kategoriler
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public int AltKategori_ID { get; set; }
    }
}
