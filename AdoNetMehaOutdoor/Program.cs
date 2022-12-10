using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetMehaOutdoor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SINIF TANIMLAMA
            DataModel dm = new DataModel();
            Kategoriler k = new Kategoriler();
            Markalar m = new Markalar();
            Nakliyeciler n = new Nakliyeciler();
            Personeller p = new Personeller();
            Satislar s = new Satislar();
            Tedarikciler t = new Tedarikciler();
            Urunler u = new Urunler();
            #endregion
            int noSecim = 0;
            string yaziSecim = "";
            string sifre = "15963";

            Console.WriteLine("                             ******************************************");
            Console.WriteLine("                             *                                        *");
            Console.WriteLine("                             *         M E H A  O U T D O O R         *");
            Console.WriteLine("                             *         H O Ş  G E L D İ N İ Z         *");
            Console.WriteLine("                             *                                        *");
            Console.WriteLine("                             ******************************************");
            Console.WriteLine("1-)KULLANICI PANELİ");
            Console.WriteLine("2-)ALIŞVERİŞ PANELİ");
            noSecim = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (noSecim < 1 || noSecim > 2)
            {
                Console.WriteLine("YANLIŞ SEÇİM YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
                noSecim = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            if (noSecim == 1)
            {
                Console.WriteLine("Hoşgeldiniz. Giriş Yapmak İçin Lütfen Şifre Giriniz");
                yaziSecim = Console.ReadLine();
                Console.Clear();
                while (yaziSecim != sifre)
                {
                    Console.WriteLine("YANLIŞ ŞİFRE GİRİŞİ LÜTFEN TEKRAR DENEYİNİZ");
                    yaziSecim = Console.ReadLine();
                    Console.Clear();
                }
                Console.WriteLine("1-)EKLEME İŞLEMLERİ");
                Console.WriteLine("2-)GÜNCELLEME İŞLEMLERİ");
                Console.WriteLine("3-)SİLME İŞLEMLERİ");
                noSecim = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                while (noSecim < 1 || noSecim > 3)
                {
                    Console.WriteLine("YANLIŞ SEÇİM YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
                    noSecim = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                if (noSecim == 1)
                {
                    Console.WriteLine("1-)KATEGORİ EKLE");
                    Console.WriteLine("2-)MARKA EKLE");
                    Console.WriteLine("3-)NAKLİYECİ EKLE");
                    Console.WriteLine("4-)PERSONEL EKLE");
                    Console.WriteLine("5-)TEDARİKÇİ EKLE");
                    Console.WriteLine("6-)ÜRÜN EKLE");
                    noSecim = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    while (noSecim < 1 || noSecim > 6)
                    {
                        Console.WriteLine("YANLIŞ SEÇİM YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
                        noSecim = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    if (noSecim == 1)
                    {
                        yaziSecim = "e";
                        while (yaziSecim == "e")
                        {
                            List<Kategoriler> kategori = dm.kategoriListele();
                            Console.WriteLine(" ID                              KATEGORİ ADI                        ALT KATEGORİ ID");
                            Console.WriteLine("________________________________________________________________________________________________________");
                            foreach (Kategoriler item in kategori)
                            {
                                Console.WriteLine($"{item.ID}-)                              {item.Ad}                               {item.AltKategori_ID}");
                                Console.WriteLine("________________________________________________________________________________________________________");
                            }
                            Console.WriteLine("Kategori Adını Giriniz");
                            k.Ad = Console.ReadLine();
                            Console.WriteLine("AltKategori ID Numarasını Giriniz");
                            k.AltKategori_ID = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (dm.kategoriEkle(k))
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ ? E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARISIZ");
                            }
                        }

                    }
                    else if (noSecim == 2)
                    {
                        yaziSecim = "e";
                        while (yaziSecim == "e")
                        {
                            Console.WriteLine("Marka Adı Giriniz");
                            m.Ad = Console.ReadLine();
                            Console.Clear();
                            if (dm.markaEkle(m))
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ ? E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARISIZ");
                            }
                        }
                    }
                    else if (noSecim == 3)
                    {
                        yaziSecim = "e";
                        while (yaziSecim == "e")
                        {
                            Console.WriteLine("Firma Adı Giriniz");
                            n.firmaAdi = Console.ReadLine();
                            Console.WriteLine("Yetkili Kişinin Ad Soyad Bilgisini Giriniz");
                            n.yetkili = Console.ReadLine();
                            Console.WriteLine("Yetkilinin Telefon Numarasını Giriniz (05xxxxxxxxx)");
                            n.telefon = Console.ReadLine();
                            if (dm.nakliyeEkle(n))
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ ? E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARISIZ");
                            }
                        }
                    }
                    else if (noSecim == 4)
                    {
                        yaziSecim = "e";
                        while (yaziSecim == "e")
                        {
                            Console.WriteLine("Personel Adını Giriniz");
                            p.ad = Console.ReadLine();
                            Console.WriteLine("Personel Soyadını Giriniz");
                            p.soyAd = Console.ReadLine();
                            Console.WriteLine("Personel Telefon Numarasını Giriniz (05xxxxxxxxx)");
                            p.telefon = Console.ReadLine();
                            Console.WriteLine("Personel Maaşını Giriniz");
                            p.maas = Convert.ToDecimal(Console.ReadLine());
                            if (dm.personelEkle(p))
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ ? E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARISIZ");
                            }
                        }
                    }
                    else if (noSecim == 5)
                    {
                        yaziSecim = "e";
                        while (yaziSecim == "e")
                        {
                            Console.WriteLine("Firma Adı Giriniz");
                            t.firma = Console.ReadLine();
                            Console.WriteLine("Yetkili Ad Soyad Giriniz");
                            t.yetkili = Console.ReadLine();
                            Console.WriteLine("Yetkili Telefon Numarası Giriniz   (05xxxxxxxxx)");
                            t.telefon = Console.ReadLine();
                            Console.WriteLine("Ürünün Alış Fiyatını Giriniz");
                            t.alisFiyat = Convert.ToDecimal(Console.ReadLine());
                            if (dm.tedarikciEkle(t))
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ ? E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARISIZ");
                            }
                        }
                    }
                    else if (noSecim == 6)
                    {
                        yaziSecim = "e";
                        while (yaziSecim == "e")
                        {
                            Console.WriteLine("Ürün Adını Giriniz");
                            u.ad = Console.ReadLine();

                            List<Kategoriler> kategori = dm.kategoriListele();
                            Console.WriteLine(" ID                              KATEGORİ ADI");
                            Console.WriteLine("__________________________________________________");
                            foreach (Kategoriler item in kategori)
                            {
                                Console.WriteLine($"{item.ID}-)                              {item.Ad}");
                                Console.WriteLine("_________________________________________________________");
                            }
                            Console.WriteLine("Ürünün Kategorisine Uygun ID Giriniz");
                            u.kategori_ID = Convert.ToInt32(Console.ReadLine());

                            List<Markalar> marka = dm.markaListele();
                            Console.WriteLine("ID           Marka Adı");
                            Console.WriteLine("___________________________");
                            foreach (Markalar item in marka)
                            {
                                Console.WriteLine($"{item.ID}-)         {item.Ad}");
                            }
                            Console.WriteLine("Ürünün Markasına Uygun ID Giriniz");
                            u.marka_ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ürünün Açıklamasını Giriniz");
                            u.aciklama = Console.ReadLine();
                            Console.WriteLine("Ürün Fiyatını Giriniz");
                            u.fiyat = Convert.ToDecimal(Console.ReadLine());
                            if (dm.urunEkle(u))
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ ? E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("EKLEME İŞLEMİ BAŞARISIZ");
                            }
                        }
                    }
                }
                else if (noSecim == 2)
                {
                    Console.WriteLine("1-)Kategori Güncelle");
                    Console.WriteLine("2-)Nakliyeci Güncelle");
                    Console.WriteLine("3-)Personel Güncelle");
                    Console.WriteLine("4-)Tedarikci Güncelle");
                    Console.WriteLine("5-)Ürün Güncelle");
                    Console.WriteLine("Güncellemek İstediğiniz Bölümü Seçiniz");
                    noSecim = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    while (noSecim < 1 || noSecim > 5)
                    {
                        Console.WriteLine("YANLIŞ SEÇİM YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
                        noSecim = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    if (noSecim == 1)
                    {
                        yaziSecim = "e";
                        while (yaziSecim == "e")
                        {
                            List<Kategoriler> kategori = dm.kategoriListele();
                            Console.WriteLine(" ID                  KATEGORİ ADI");
                            Console.WriteLine("____________________________________");
                            foreach (Kategoriler item in kategori)
                            {
                                Console.WriteLine($"{item.ID}           {item.Ad}");
                                Console.WriteLine("_________________________________");
                            }
                            Console.WriteLine("Güncellemek İstediğiniz ID numarasını Giriniz");
                            k.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Güncellemek İstediğiniz Kategori Adını Giriniz");
                            k.Ad = Console.ReadLine();
                            Console.Clear();
                            if (dm.kategoriDegistir(k))
                            {
                                Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARISIZ");
                            }
                        }

                    }
                    else if (noSecim == 2)
                    {
                        Console.WriteLine("1-)Yetkili Güncelle");
                        Console.WriteLine("2-)Telefon Güncelle");
                        noSecim = Convert.ToInt32(Console.ReadLine());
                        while (noSecim < 1 || noSecim > 2)
                        {
                            Console.WriteLine("YANLIŞ SEÇİM YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
                            noSecim = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }
                        if (noSecim == 1)
                        {
                            yaziSecim = "e";
                            while (yaziSecim == "e")
                            {
                                List<Nakliyeciler> nakliye = dm.nakliyeListele();
                                Console.WriteLine(" ID               FİRMA ADI                     YETKLİLİ ADI               TELEFON");
                                Console.WriteLine("________________________________________________________________________________________________");
                                foreach (Nakliyeciler item in nakliye)
                                {
                                    Console.WriteLine($"{item.ID}           {item.firmaAdi}                  {item.yetkili}                {item.telefon}");
                                    Console.WriteLine("_____________________________________________________________________________________________");
                                }
                                Console.WriteLine("Güncellemek İstediğiniz Yetkilinin ID Numarasını Giriniz");
                                n.ID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Güncellemek İstediğiniz Ad Soyad Giriniz");
                                n.yetkili = Console.ReadLine();
                                if (dm.nakliyeYetkiliGuncelle(n))
                                {
                                    Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ E/H");
                                    yaziSecim = Console.ReadLine();
                                    yaziSecim.ToLower();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARISIZ");
                                }
                            }
                        }
                        else if (noSecim == 2)
                        {
                            yaziSecim = "e";
                            while (yaziSecim == "e")
                            {
                                List<Nakliyeciler> nakliye = dm.nakliyeListele();
                                Console.WriteLine(" ID               FİRMA ADI                     YETKLİLİ ADI               TELEFON");
                                Console.WriteLine("________________________________________________________________________________________________");
                                foreach (Nakliyeciler item in nakliye)
                                {
                                    Console.WriteLine($"{item.ID}           {item.firmaAdi}                  {item.yetkili}                {item.telefon}");
                                    Console.WriteLine("_____________________________________________________________________________________________");
                                }
                                Console.WriteLine("Güncellemek İstediğiniz Yetkilinin ID Numarasını Giriniz");
                                n.ID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Güncellemek İstediğiniz Telefon Numarasını Giriniz (05xxxxxxxxx)");
                                n.telefon = Console.ReadLine();
                                if (dm.nakliyeTelefonGuncelle(n))
                                {
                                    Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ E/H");
                                    yaziSecim = Console.ReadLine();
                                    yaziSecim.ToLower();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARISIZ");
                                }
                            }
                        }
                    }
                    else if (noSecim == 3)
                    {
                        Console.WriteLine("1-)Maaş Güncelle");
                        Console.WriteLine("2-)Soyad Güncelle");
                        Console.WriteLine("3-)Telefon Güncelle");
                        noSecim = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        while (noSecim < 1 || noSecim > 3)
                        {
                            Console.WriteLine("YANLIŞ SEÇİM YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
                            noSecim = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }
                        if (noSecim == 1)
                        {
                            List<Personeller> personel = dm.personelListele();
                            Console.WriteLine("ID        PERSONEL ADI    PERSONEL SOYADI            TELEFON NO            MAAŞ");
                            foreach (Personeller item in personel)
                            {
                                Console.WriteLine($"{item.ID}           {item.ad}           {item.soyAd}                  {item.telefon}          {item.maas}");
                            }
                            Console.WriteLine("Güncellemek İstediğiniz Personelin ID Numarasını Giriniz");
                            p.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Seçtiğiniz Personelin Güncel Maaşını Giriniz");
                            p.maas = Convert.ToDecimal(Console.ReadLine());

                            if (dm.personelMaasGuncelleme(p))
                            {
                                Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARILI DEVAM ETMEK İSTER MİSİNİZ E/H");
                                yaziSecim = Console.ReadLine();
                                yaziSecim.ToLower();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("GÜNCELLEME İŞLEMİ BAŞARISIZ");
                            }
                        }
                        else if (noSecim == 2)
                        {

                        }
                        else if (noSecim == 3)
                        {

                        }
                    }
                    else if (noSecim == 4)
                    {

                    }
                    else if (noSecim == 5)
                    {

                    }
                }
                else if (noSecim == 3)
                {

                }
            }
            else if (noSecim == 2)
            {

            }




        }
    }
}
