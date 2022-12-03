using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehaOutdoor
{
    public class Personeller
    {
        public string personelEkle()
        {
            SqlConnection personelEkle = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand personelYaz = personelEkle.CreateCommand();
            Console.WriteLine("Personel Adını Giriniz");
            string ad = Console.ReadLine();

            Console.WriteLine("Personel Soyadı Giriniz");
            string soyAd = Console.ReadLine();

            Console.WriteLine("Personel Telefon Numarası Giriniz");
            string telefon = Console.ReadLine();

            Console.WriteLine("Personelin Maaşını Giriniz");
            decimal maas = Convert.ToDecimal(Console.ReadLine());
            personelYaz.CommandText = $"INSERT INTO Personeller(Ad,Soyad,Telefon,Maas) VALUES ('{ad}','{soyAd}','{telefon}',{maas})";
            personelEkle.Open();
            personelYaz.ExecuteNonQuery();
            personelEkle.Close();

            return "";
        }
        public string personelGor()
        {
            SqlConnection personelGor = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand personelGetir = personelGor.CreateCommand();
            personelGetir.CommandText = "SELECT Personeller.Ad,Personeller.Soyad,Personeller.Telefon,Personeller.Maas FROM Personeller";
            personelGor.Open();
            SqlDataReader reader = personelGetir.ExecuteReader();
            Console.WriteLine("Adı         Soyad            Telefon             Maaş");
            Console.WriteLine("______________________________________________________________________________");
            while (reader.Read())
            {
                string ad = reader.GetString(0);
                string soyad = reader.GetString(1);
                string telefon = reader.GetString(2);
                decimal maas = reader.GetDecimal(3);
                Console.WriteLine("_________________________________________________");
            }
            personelGor.Close();
            return "";
        }
        public string personelGuncelle()
        {
            SqlConnection personelGuncelle = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand personelGuncel = personelGuncelle.CreateCommand();
            Console.WriteLine("ID           Ad      Soyad       Telefon     Maaş"  );
            Console.WriteLine("________________________________________________________");
            personelGuncel.CommandText = "SELECT * FROM Personeller";
            Console.WriteLine("*-*Güncellemek İstediğiniz ID'sini Seçiniz*-*");
            int personel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1-Ad");
            Console.WriteLine("2-Soyad");
            Console.WriteLine("3-Telefon");
            Console.WriteLine("4-Maaş");
            Console.WriteLine("-*-Personelin Hangi Bilgisini Değiştirmek İstersiniz?-*-");
            int psecim = Convert.ToInt32(Console.ReadLine());
            while (psecim <1 || psecim >5)
            {
                Console.WriteLine("YANLIŞ SEÇİM YAPTINIZ LÜTFEN TEKRAR DENEYİNİZ");
                psecim = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            if (psecim == 1)
            {
                Console.WriteLine("Lütfen Adı Güncelleyiniz");
                string gAd = Console.ReadLine();
                personelGuncel.CommandText = $"UPDATE Personeller\r\nSET Ad='{gAd}'\r\nWHERE ID={personel};";
            }
            else if (psecim == 2)
            {
                Console.WriteLine("Lütfen Soyadı Güncelleyiniz");
                string gsoyAd = Console.ReadLine();
                personelGuncel.CommandText = $"UPDATE Personeller\r\nSET Soyad='{gsoyAd}'\r\nWHERE ID={personel};";
            }
            else if (psecim == 3)
            {
                Console.WriteLine("Lütfen Telefon Numarasını Güncelleyiniz");
                string tel = Console.ReadLine();
                personelGuncel.CommandText = $"UPDATE Personeller\r\nSET Telefon='{tel}'\r\nWHERE ID={personel};";
            }
            else if (psecim == 4)
            {
                Console.WriteLine("Lütfen Maaş Güncelleyiniz");
                string maaas = Console.ReadLine();
                personelGuncel.CommandText = $"UPDATE Personeller\r\nSET Maas={maaas}\r\nWHERE ID={personel};";
            }
           
            
            return "";
        }
    }
}
