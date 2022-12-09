﻿using System;
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
        public bool nakliyeYetkiliGuncelle()
        {
            Nakliyeciler n = new Nakliyeciler();
            try
            {
                cmd.CommandText = "UPDATE Nakliyeciler SET Yetkili = @yetkili WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yetkili", n.yetkili);
                cmd.Parameters.AddWithValue("@id", n.ID);
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
        public bool nakliyeTelefonGuncelle()
        {
            Nakliyeciler n = new Nakliyeciler();
            try
            {
                cmd.CommandText = "UPDATE Nakliyeciler SET Telefon = @telefon WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@telefon", n.telefon);
                cmd.Parameters.AddWithValue("@id", n.ID);
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
        public bool personelSil()
        {
            Personeller p = new Personeller();
            try
            {
                cmd.CommandText = "UPDATE Personeller SET Aktif = 0 WHERE ID=@id";
                cmd.Parameters.Clear();
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

        #region SATIŞ METOTLARI
        public List<Satislar> satisListele()
        {
            List<Satislar> satis = new List<Satislar>();
            List<Urunler> urun = new List<Urunler>();
            List<Personeller> personel = new List<Personeller>();
            List<Nakliyeciler> nakliye = new List<Nakliyeciler>();
            try
            {
                cmd.CommandText = "SELECT S.ID,U.Ad,P.Ad,S.Adet,N.FirmaAdi FROM Satislar AS S JOIN Personeller AS P  ON P.ID = S.Personel_ID JOIN Urunler AS U ON U.ID = S.Urun_ID JOIN Nakliyeciler AS N ON N.ID=S.Kargo_ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader yazdir = cmd.ExecuteReader();
                while (yazdir.Read())
                {
                    Satislar s = new Satislar();
                    Urunler u = new Urunler();
                    Personeller p = new Personeller();
                    Nakliyeciler n = new Nakliyeciler();
                    s.ID = yazdir.GetInt32(0);
                    u.ad = yazdir.GetString(1);
                    p.ad = yazdir.GetString(2);
                    s.adet = yazdir.GetInt16(3);
                    n.firmaAdi = yazdir.GetString(4);
                    satis.Add(s);
                    urun.Add(u);
                    personel.Add(p);
                    nakliye.Add(n);

                }
                return satis;

            }
            catch
            {
                return null;
            }
            finally { con.Close(); }

        }

        #endregion

        #region TEDARİKÇİ METOTLARI
        public bool tedarikciEkle(Tedarikciler t)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Tedarikciler(Firma,Yetkili,Telefon,AlisFiyat,Aktif) VALUES(@firmadi,@yetkili,@telefon,@alisfiyat,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firmadi", t.firma);
                cmd.Parameters.AddWithValue("@yetkili", t.yetkili);
                cmd.Parameters.AddWithValue("@telefon", t.telefon);
                cmd.Parameters.AddWithValue("@alisfiyat", t.alisFiyat);
                con.Open();
                cmd.ExecuteNonQuery();
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
        public List<Tedarikciler> tedarikciListele()
        {
            List<Tedarikciler> tedarikci = new List<Tedarikciler>();
            try
            {
                cmd.CommandText = "SELECT ID, Firma, Yetkili, Telefon, AlisFiyat FROM Tedarikciler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tedarikciler t = new Tedarikciler();
                    t.ID = reader.GetInt32(0);
                    t.firma = reader.GetString(1);
                    t.yetkili = reader.GetString(2);
                    t.telefon = reader.GetString(3);
                    t.alisFiyat = reader.GetDecimal(4);
                    tedarikci.Add(t);
                }
                return tedarikci;
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
        public bool tedarikciYetkiliGuncelleme()
        {
            Tedarikciler t = new Tedarikciler();
            try
            {
                cmd.CommandText = "UPDATE Tedarikciler SET Yetkili = @yetkili WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yetkili", t.yetkili);
                cmd.Parameters.AddWithValue("@id", t.ID);
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
        public bool tedarikciTelefonGuncelleme()
        {
            Tedarikciler t = new Tedarikciler();
            try
            {
                cmd.CommandText = "UPDATE Tedarikciler SET Telefon = @telefon WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@telefon", t.telefon);
                cmd.Parameters.AddWithValue("@id", t.ID);
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
        public bool tedarikciAlisFiyatGuncelleme()
        {
            Tedarikciler t = new Tedarikciler();
            try
            {
                cmd.CommandText = "UPDATE Tedarikciler SET AlisFiyat = @alis WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@alis", t.alisFiyat);
                cmd.Parameters.AddWithValue("@id", t.ID);
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
        public bool tedarikciSil()
        {
            Tedarikciler t = new Tedarikciler();
            try
            {
                cmd.CommandText = "UPDATE Tedarikciler SET Aktif = 0 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", t.ID);
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

        #region ÜRÜN METOTLARI
        public bool urunEkle(Urunler u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Urunler(Ad,Kategori_ID,Marka_ID,Aciklama,Fiyat,Stok,GuvenlikStogu,Aktif) VALUES (@ad,@kategorid,@markaid,@aciklama,@fiyat,@stok,@gstok,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ad", u.ad);
                cmd.Parameters.AddWithValue("@kategorid", u.kategori_ID);
                cmd.Parameters.AddWithValue("@markaid", u.marka_ID);
                cmd.Parameters.AddWithValue("@aciklama", u.aciklama);
                cmd.Parameters.AddWithValue("@fiyat", u.fiyat);
                cmd.Parameters.AddWithValue("@stok", u.stok);
                cmd.Parameters.AddWithValue("@gstok", u.guvenlikStogu);
                con.Open();
                cmd.ExecuteNonQuery();
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
        public List<Urunler> urunListele()
        {
            List<Urunler> urun = new List<Urunler>();
            List<Markalar> marka = new List<Markalar>();
            List<Kategoriler> kategori = new List<Kategoriler>();

            try
            {
                cmd.CommandText = "SELECT u.ID,u.Ad,k.Ad,m.Ad,u.Aciklama,u.Fiyat,u.Stok FROM Urunler AS U JOIN Markalar AS M ON m.ID=u.Marka_ID JOIN Kategoriler AS K ON K.ID = u.Kategori_ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader yazdir = cmd.ExecuteReader();
                while (yazdir.Read())
                {
                    Urunler u = new Urunler();
                    Markalar m = new Markalar();
                    Kategoriler k = new Kategoriler();
                    u.ID = yazdir.GetInt32(0);
                    u.ad = yazdir.GetString(1);
                    k.Ad = yazdir.GetString(2);
                    m.Ad = yazdir.GetString(3);
                    u.aciklama = yazdir.GetString(4);
                    u.fiyat = yazdir.GetDecimal(5);
                    u.stok = yazdir.GetInt32(6);
                    urun.Add(u);
                    marka.Add(m);
                    kategori.Add(k);
                }
                return urun;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        public bool urunSil()
        {
            Urunler urun = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Aktif = 0 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", urun.ID);
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
        public bool urunAdiGuncelle()
        {
            Urunler u = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Ad = @ad WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@alis", u.ad);
                cmd.Parameters.AddWithValue("@id", u.ID);
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
        public bool urunKategoriGuncelle()
        {
            Urunler u = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Kategori_ID = @katid WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@katid", u.kategori_ID);
                cmd.Parameters.AddWithValue("@id", u.ID);
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
        public bool urunMarkaGuncelle()
        {
            Urunler u = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Marka = @marka WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@marka", u.marka_ID);
                cmd.Parameters.AddWithValue("@id", u.ID);
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
        public bool urunAciklamaGuncelle()
        {
            Urunler u = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Aciklama = @aciklama WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@aciklama", u.aciklama);
                cmd.Parameters.AddWithValue("@id", u.ID);
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
        public bool urunFiyatGuncelle()
        {
            Urunler u = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Fiyat = @fiyat WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fiyat", u.fiyat);
                cmd.Parameters.AddWithValue("@id", u.ID);
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
        public bool urunStokGuncelle()
        {
            Urunler u = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET Stok = @stok WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@stok", u.stok);
                cmd.Parameters.AddWithValue("@id", u.ID);
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
        public bool urunGstokGuncelle()
        {
            Urunler u = new Urunler();
            try
            {
                cmd.CommandText = "UPDATE Urunler SET GuvenlikStogu = @gstok WHERE ID = @ id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@gstok", u.guvenlikStogu);
                cmd.Parameters.AddWithValue("@id", u.ID);
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
