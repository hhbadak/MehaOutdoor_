using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetMehaOutdoor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataModel dm = new DataModel();
            Kategoriler k = new Kategoriler();

            int noSecim = 0;
            string yaziSecim = "";

            Console.WriteLine("Lütfen Kategori Adını Giriniz");
            yaziSecim = Console.ReadLine();

            Console.Clear();

            List<Kategoriler> kategori = dm.kategoriListele();

            Console.WriteLine("ID           Kategori Adı            Alt Kategori ID");
            Console.WriteLine("_______________________________________________________");

            foreach (Kategoriler item in kategori)
            {
                Console.WriteLine($"{item.ID}-)     {item.Ad}   \t\t{item.AltKategori_ID}");
                Console.WriteLine("__________________________________________________________");
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("Lütfen üst Kategori Seçiniz");
            noSecim = Convert.ToInt32(Console.ReadLine());

            k.Ad = yaziSecim;
            k.AltKategori_ID = noSecim;

            if (dm.kategoriEkle(k))
            {
                Console.WriteLine("Ekleme İşlemi Başarılı");
            }
            else
            {
                Console.WriteLine("Ekleme İşlemi Başarısız.");
            }



        }
    }
}
