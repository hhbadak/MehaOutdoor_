using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MehaOutdoor
{
    public class Markalar
    {
        public int id;
        public string ad;
        public string mensei;
        public string markaEkle()
        {
            SqlConnection markaEkle = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand markaYaz = markaEkle.CreateCommand();

            Console.WriteLine("Marka Adı Giriniz");
            string marka = Console.ReadLine();

            Console.WriteLine("Üretilen Ülkeyi Giriniz");
            string mensei = Console.ReadLine();

            markaYaz.CommandText = $"INSERT INTO Markalar (Ad, Mensei) VALUES ('{marka}', '{mensei}')";
            markaEkle.Open();
            markaYaz.ExecuteNonQuery();
            markaEkle.Close();
            return $"{id} {ad} {mensei}";
        }
        public string markaGor()
        {
            SqlConnection markaGor = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security = True");
            SqlCommand markaGetir = markaGor.CreateCommand();
            markaGetir.CommandText = "SELECT Markalar.Ad, Markalar.Mensei FROM Markalar";
            markaGor.Open();
            SqlDataReader reader = markaGetir.ExecuteReader();
            Console.WriteLine("Marka Adı        Menşei Adı");
            Console.WriteLine("_________________________________________________");
            while (reader.Read())
            {
                string ad = reader.GetString(0);
                string mensei = reader.GetString(1);
                Console.WriteLine($"  {ad}             {mensei}");
                Console.WriteLine("_________________________________________________");
            }
            markaGor.Close();
            return "";
        }
    }
}
