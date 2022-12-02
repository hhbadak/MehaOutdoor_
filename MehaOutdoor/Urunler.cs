using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            Console.WriteLine("Adı         Soyad            Telefon             Maaş");
            Console.WriteLine("______________________________________________________________________________");
            while (reader.Read())
            {
                string uAd=reader.GetString(0);
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
    }
}
