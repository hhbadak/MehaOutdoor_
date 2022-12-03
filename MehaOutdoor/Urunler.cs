using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehaOutdoor
{
    public class Urunler
    {
        public string urunEkle()
        {
            SqlConnection urunEkle = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand urunYaz = urunEkle.CreateCommand();

            Console.WriteLine("Ürün Adı Giriniz");
            string ad = Console.ReadLine();

            Console.WriteLine("ID           Ad             ÜstKategori ID");
            Console.WriteLine("_____________________________________________");
            urunYaz.CommandText = ("SELECT * FROM Kategoriler");
            urunEkle.Open();
            SqlDataReader reader = urunYaz.ExecuteReader();
            while (reader.Read())
            {
                int uAd = reader.GetInt32(0);
                string kAd = reader.GetString(1);
                int mAd = reader.GetInt32(2);
              
                Console.WriteLine($"{uAd}\t{kAd}\t{mAd}");
                Console.WriteLine("________________________________________________");
            }
            urunYaz.CommandText = ("SELECT * FROM Kategoriler");
            Console.WriteLine("Kategori ID Giriniz");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("ID           Ad             Menşei");
            Console.WriteLine("__________________________________________");
            urunYaz.CommandText = ("SELECT * FROM Markalar");
            Console.WriteLine("Marka ID Giriniz");
            int markaId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ürün Açıklamasını Yapınız");
            string aciklama = Console.ReadLine();

            Console.WriteLine("Ürün Fiyatını Yazınız");
            decimal fiyat = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Stok Miktarını Giriniz");
            int stok = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Aylık Satılan Ürün Miktarını Giriniz");
            int guvenlikStogu = Convert.ToInt32(Console.ReadLine());

            urunYaz.CommandText = $"INSERT INTO Urunler(Ad,Kategori_ID,Marka_ID,Aciklama,Fiyat,Stok,GuvenlikStogu) VALUES ('{ad}',{id},{markaId},'{aciklama}',{fiyat},{stok},{guvenlikStogu})";
            urunEkle.Open();
            urunYaz.ExecuteNonQuery();
            urunEkle.Close();
            return "";
        }
        public string urunGor()
        {
            SqlConnection urunGor = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand urunGetir = urunGor.CreateCommand();
            urunGetir.CommandText = "SELECT U.Ad,K.Ad,M.Ad,U.Aciklama,U.Fiyat,U.Stok,U.GuvenlikStogu FROM Urunler AS U\r\nJOIN Kategoriler AS K ON K.ID = U.Kategori_ID\r\nJOIN Markalar AS M ON M.ID = U.Marka_ID";
            urunGor.Open();
            SqlDataReader reader = urunGetir.ExecuteReader();
            Console.WriteLine("Ürün Adı         Kategori Adı            Marka Adı             Açıklama          Fiyat       Stok        Güvenlik Stoğu");
            Console.WriteLine("______________________________________________________________________________________________________________________________");
            while (reader.Read())
            {
                string uAd = reader.GetString(0);
                string kAd = reader.GetString(1);
                string mAd = reader.GetString(2);
                string uAciklama = reader.GetString(3);
                decimal uFiyat = reader.GetDecimal(4);
                int uStok = reader.GetInt32(5);
                int uGuvenlikStogu = reader.GetInt32(6);
                Console.WriteLine($"{uAd}\t{kAd}\t{mAd}\t{uAciklama}\t{uFiyat}\t{uStok}\t{uGuvenlikStogu}");
                Console.WriteLine("____________________________________________________________________________________________________");
            }
            urunGor.Close();
            return "";

        }
        public string musteriUrunGor()
        {
            SqlConnection musteriUrunGor = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand musteriUrunGetir = musteriUrunGor.CreateCommand();
            musteriUrunGetir.CommandText = "SELECT U.ID,U.Ad,K.Ad,M.Ad,U.Aciklama,U.Fiyat,U.Stok FROM Urunler AS U\r\nJOIN Kategoriler AS K ON K.ID = U.Kategori_ID\r\nJOIN Markalar AS M ON M.ID = U.Marka_ID";
            musteriUrunGor.Open();
            SqlDataReader reader = musteriUrunGetir.ExecuteReader();
            Console.WriteLine("Ürün ID         Ürün Adı         Kategori Adı            Marka Adı             Açıklama          Fiyat       Stok ");
            Console.WriteLine("________________________________________________________________________________________________________________________");
            int uID = reader.GetInt32(0);
            int secenek = 0;
            while (reader.Read())
            {

                uID = reader.GetInt32(0);
                string uAd = reader.GetString(1);
                string kAd = reader.GetString(2);
                string mAd = reader.GetString(3);
                string uAciklama = reader.GetString(4);
                decimal uFiyat = reader.GetDecimal(5);
                int uStok = reader.GetInt32(6);
                int uGuvenlikStogu = reader.GetInt32(6);
                Console.WriteLine($"{uAd}\t{kAd}\t{mAd}\t{uAciklama}\t{uFiyat}\t{uStok}\t{uGuvenlikStogu}");
                Console.WriteLine("____________________________________________________________________________________________________");
            }
            Urunler urun = new Urunler();
            Console.WriteLine(urun.musteriUrunGor());
            Console.WriteLine("Almak İstediğiniz Ürün ID'sini Giriniz");
            secenek = Convert.ToInt32(Console.ReadLine());
            while (secenek != uID)
            {
                Console.WriteLine("YANLIŞ TUŞLAMA YAPTINIZ TEKRAR DENEYİNİZ");
                secenek = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            if (true)
            {

            }
            musteriUrunGor.Close();
            return "";
        }



    }
}
