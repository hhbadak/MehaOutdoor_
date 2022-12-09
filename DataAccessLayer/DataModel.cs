using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
                cmd.CommandText = "INSERT INTO Kategoriler(Ad,AltKategori_ID,Aktif) VALUES (@kategoriAd,@altKategoriID,1)";
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
                cmd.CommandText = "SELECT Kategoriler.ID,Kategoriler.Ad,Kategoriler.AltKategori_ID=Ad FROM Kategoriler";
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
        public Kategoriler kategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Ad,AltKategori_ID=Ad FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader yazdir = cmd.ExecuteReader();
                Kategoriler k = new Kategoriler();
                while (yazdir.Read())
                {
                    k.ID = yazdir.GetInt32(0);
                    k.Ad = yazdir.GetString(1);
                    k.AltKategori_ID = yazdir.GetInt32(2);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public bool kategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Aktif = 0 ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }

        }
        public bool kategoriDegistir(string ad, int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Ad=@ad WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@id", id);
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        #endregion

        #region MARKA METOTLARI

        public bool markaEkle(Markalar m)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Markalar(Ad,Mensei,Aktif) VALUES ('@ad','@mensei',1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ad", m.Ad);
                cmd.Parameters.AddWithValue("@mensei", m.Mensei);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public bool markaSil(int id)
        {
            DataModel dm = new DataModel();
            try
            {
                Markalar m = new Markalar();
                cmd.CommandText = "UPDATE Markalar SET Aktif = 0 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", m.ID);
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public List<Markalar> markaListele()
        {
            List<Markalar> marka = new List<Markalar>();
            try
            {
                cmd.CommandText = "SELECT ID,Ad,Mensei FROM Markalar";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader yazdir = cmd.ExecuteReader();
                while (yazdir.Read())
                {
                    Markalar m = new Markalar();
                    m.ID = yazdir.GetInt32(0);
                    m.Ad = yazdir.GetString(1);
                    m.Mensei = yazdir.GetString(2);
                    marka.Add(m);
                }
                return marka;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        #endregion

        #region NAKLİYE METOTLARI
        DataModel dm = new DataModel();

        public bool nakliyeEkle(Nakliyeciler n)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Nakliyeciler(FirmaAdi,Yetkili,Telefon,Aktif) VALUES (@firmadi,@yetkili,@telefon,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firmadi", n.firmaAdi);
                cmd.Parameters.AddWithValue("@yetkili", n.yetkili);
                cmd.Parameters.AddWithValue("@telefon", n.telefon);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public List<Nakliyeciler> nakliyeListele()
        {
            List<Nakliyeciler> nakliye = new List<Nakliyeciler>();
            try
            {
                cmd.CommandText = "SELECT ID,FirmaAdi,Yetkili,Telefon FROM Nakliyeciler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader yazdir = cmd.ExecuteReader();
                while (yazdir.Read())
                {
                    Nakliyeciler n = new Nakliyeciler();
                    n.ID = yazdir.GetInt32(0);
                    n.firmaAdi = yazdir.GetString(1);
                    n.yetkili = yazdir.GetString(2);
                    n.telefon = yazdir.GetString(3);
                    nakliye.Add(n);
                }
                return nakliye;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public bool nakliyeGuncelle(int id) // bakılacak
        {
            //int noSecim = 0;
            try
            {
                //cmd.CommandText = "UPDATE Nakliyeciler SET @sec WHERE ID = @id";
                //cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@sec",)

                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public bool nakliyeSil(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Nakliyeciler SET Aktif = 0 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        #endregion

        #region PERSONEL METOTLARI
        public bool personelEkle(Personeller p)
        {
            try
            {
                Personeller personel = new Personeller();
                cmd.CommandText = "INSERT INTO Personeller(Ad,Soyad,Telefon,Maas,Aktif) VALUES (@ad,@soyAd,@telefon,@maas,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ad", personel.ad);
                cmd.Parameters.AddWithValue("@soyAd", personel.soyAd);
                cmd.Parameters.AddWithValue("@telefon", personel.telefon);
                cmd.Parameters.AddWithValue("@maas", personel.maas);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public List<Personeller> personelListele()
        {
            List<Personeller> personel = new List<Personeller>();
            try
            {
                cmd.CommandText = "SELECT ID,Ad,Soyad,Telefon,Maas FROM Personeller";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader yazdir = cmd.ExecuteReader();
                while (yazdir.Read())
                {
                    Personeller p = new Personeller();
                    p.ID = yazdir.GetInt32(0);
                    p.ad = yazdir.GetString(1);
                    p.soyAd = yazdir.GetString(2);
                    p.telefon = yazdir.GetString(3);
                    p.maas = yazdir.GetDecimal(4);
                    personel.Add(p);
                }
                return personel;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public bool personelMaasGuncelleme()
        {
            Personeller p = new Personeller();
            try
            {
                cmd.CommandText = "UPDATE Personeller SET Maas = @maas WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@maas", p.maas);
                cmd.Parameters.AddWithValue("@id", p.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public bool personelSoyAdGuncelleme()
        {
            Personeller p = new Personeller();
            try
            {
                cmd.CommandText = "UPDATE Personeller SET Soyad = @soyad WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@soyad", p.soyAd);
                cmd.Parameters.AddWithValue("@id", p.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        public bool personelTelefonGuncelleme()
        {
            Personeller p = new Personeller();
            try
            {
                cmd.CommandText = "UPDATE Personeller SET Telefon = @telefon WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@telefon", p.telefon);
                cmd.Parameters.AddWithValue("@id", p.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }


        #endregion

    }
}
