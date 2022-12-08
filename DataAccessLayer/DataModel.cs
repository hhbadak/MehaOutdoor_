using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.baglanti);
            cmd = con.CreateCommand();
        }
        #region KATEGORİ METOTLARI

        public bool kategoriEkle(Kategoriler k)
        {
            try
            {
                DataModel dm = new DataModel();
                cmd.CommandText = "INSERT INTO Kategoriler(Ad,AltKategori_ID) VALUES (@kategoriAd,@altKategoriID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriAd", k.Ad);
                cmd.Parameters.AddWithValue("@altKategoriID", k.AltKategori_ID);
                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Kategoriler> kategoriListele()
        {
            List<Kategoriler> kategori = new List<Kategoriler>();
            try
            {
                cmd.CommandText = "SELECT Kategoriler.ID,Kategoriler.Ad,Kategoriler.AltKategori_ID FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader yazdir = cmd.ExecuteReader();
                while (yazdir.Read())
                {
                    Kategoriler k = new Kategoriler();
                    k.ID = yazdir.GetInt32(0);
                    k.Ad = yazdir.GetString(1);
                    k.AltKategori_ID = yazdir.GetInt32(2);
                    
                    kategori.Add(k);
                }
                return kategori;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

    }
}
