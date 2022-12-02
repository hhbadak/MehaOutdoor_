using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehaOutdoor
{
    public class Tedarikciler
    {
        public string tedarikciEkle()
        {
            SqlConnection tedarikciEkle = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand tedarikciYaz = tedarikciEkle.CreateCommand();

            Console.WriteLine("Firma Adı Giriniz");
            string firma = Console.ReadLine();

            Console.WriteLine("Yetkili Ad Soyad Giriniz");
            string yetkili = Console.ReadLine();

            Console.WriteLine("Yetkili Telefon Numarasını Giriniz");
            string telefon = Console.ReadLine();

            tedarikciYaz.CommandText = $"INSERT INTO Tedarikciler(Firma,Yetkili,Telefon) VALUES ('{firma}','{yetkili}','{telefon}')";
            tedarikciEkle.Open();
            tedarikciYaz.ExecuteNonQuery();
            tedarikciEkle.Close();
            return "";
        }
        public string tedarikciGor()
        {
            SqlConnection tedarikciGor = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand tedarikciGetir = tedarikciGor.CreateCommand();
            tedarikciGetir.CommandText = "SELECT Tedarikciler.Firma,Tedarikciler.Yetkili,Tedarikciler.Telefon FROM Tedarikciler";
            tedarikciGor.Open();
            SqlDataReader reader = tedarikciGetir.ExecuteReader();

            Console.WriteLine("Adı         Soyad            Telefon             Maaş");
            Console.WriteLine("______________________________________________________________________________");

            while (reader.Read())
            {
                string firma = reader.GetString(0);
                string yetkili = reader.GetString(1);
                string telefon = reader.GetString(2);
                Console.WriteLine($"{firma}    {yetkili}     {telefon}");
                Console.WriteLine("_________________________________________________");
            }
            tedarikciGor.Close();
            return "";
        }
    }
}
