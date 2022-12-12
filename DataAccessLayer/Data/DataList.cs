using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class DataList
    {
        public DataList()
        {
            kategori = new Kategoriler();
            marka = new Markalar();
            nakliye = new Nakliyeciler();
            personel = new Personeller();
            tedarikci = new Tedarikciler();
            urun = new Urunler();
            satis = new Satislar();
        }

        public Kategoriler kategori { get; set; }
        public Markalar marka { get; set; }
        public Nakliyeciler nakliye { get; set; }
        public Personeller personel { get; set; }
        public Tedarikciler tedarikci { get; set; }
        public Urunler urun { get; set; }
        public Satislar satis { get; set; }
    }
}
