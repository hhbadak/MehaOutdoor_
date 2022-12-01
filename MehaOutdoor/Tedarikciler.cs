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

            return "";
        }
    }
}
