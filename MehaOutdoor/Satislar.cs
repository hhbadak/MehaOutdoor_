using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehaOutdoor
{
    public class Satislar
    {
        public string satisGor()
        {
            SqlConnection satisGor = new SqlConnection(@"Data Source = DESKTOP-F78GTM3\SQLEXPRESS; Initial Catalog = Meha_Outdoor_DB; Integrated Security=True");
            SqlCommand satisGetir = satisGor.CreateCommand();
            satisGetir.CommandText = "SELECT U.Ad,P.Ad,S.Adet,N.FirmaAdi FROM Satislar AS S\r\nJOIN Urunler AS U ON U.ID = S.Urun_ID\r\nJOIN Personeller AS P ON P.ID = S.Personel_ID\r\nJOIN Nakliyeciler AS N ON N.ID = S.Kargo_ID";
            satisGor.Open();
            SqlDataReader reader = satisGetir.ExecuteReader();
            while (reader.Read())
            {
                string urunAd = reader.GetString(0);
                string personelAd = reader.GetString(1);
                int adet = reader.GetInt32(2);
                string firma = reader.GetString(3);
            }
            satisGor.Close();
            return "";
        }
    }
}
