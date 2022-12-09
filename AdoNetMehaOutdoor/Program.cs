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
            Console.WriteLine("******************************************");
            Console.WriteLine("*                                        *");
            Console.WriteLine("*         M E H A  O U T D O O R         *");
            Console.WriteLine("*                                        *");
            Console.WriteLine("******************************************");





        }
    }
}
