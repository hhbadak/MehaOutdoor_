using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Urunler
    {
        public int ID { get; set; }
        public string ad { get; set; }
        public int kategori_ID { get; set; }
        public int marka_ID { get; set; }
        public string aciklama { get; set; }
        public string fiyat { get; set; }
        public string stok { get; set; }
        public string guvenlikStogu { get; set; }

    }
}
