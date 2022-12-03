using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MehaOutdoor
{
    public class Kategoriler
    {

        public string KategoriGor()
        {
            SqlConnection kategoriGor = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security = True");
            SqlCommand kategoriGetir = kategoriGor.CreateCommand();
            kategoriGetir.CommandText = "SELECT Ka.Ad, K.Ad AS UstKategori FROM Kategoriler AS Ka\r\nJOIN Kategoriler AS K ON K.ID = Ka.AltKategori_ID";
            kategoriGor.Open();
            SqlDataReader reader = kategoriGetir.ExecuteReader();
            Console.WriteLine("ID      Kategori Adı     Üst Kategori Adı");
            Console.WriteLine("_________________________________________________");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string ad = reader.GetString(1);
                string altKategoriAdi = reader.GetString(2);
                Console.WriteLine($"{id}-)   {ad}         {altKategoriAdi}");
                Console.WriteLine("_________________________________________________");
            }
            kategoriGor.Close();
            return $"";
        }
        public string kategoriEkle()
        {
            SqlConnection kategoriEkle = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand kategoriYaz = kategoriEkle.CreateCommand();

            Console.WriteLine("Kategori Adı Belirtiniz");
            string kategori = Console.ReadLine();

            kategoriYaz.CommandText = ("SELECT * FROM Kategoriler ");
            Console.WriteLine("Üst Kategori Belirtiniz");
            int altKategori = Convert.ToInt32(Console.ReadLine());

            kategoriYaz.CommandText = $"INSERT INTO Kategoriler (Ad, AltKategori_ID) VALUES ('{kategori}', {altKategori})";
            kategoriEkle.Open();
            kategoriYaz.ExecuteNonQuery();
            kategoriEkle.Close();
            return "";
        }

    }
}
