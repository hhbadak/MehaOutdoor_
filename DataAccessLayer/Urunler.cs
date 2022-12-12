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
        public decimal fiyat { get; set; }
        public int adet { get; set; }
        public int stok { get; set; }
        public int guvenlikStogu { get; set; }
        public int Aktif { get; set; }

    }
}
