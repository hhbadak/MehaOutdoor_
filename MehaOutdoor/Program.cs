﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehaOutdoor
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region SINIF TANIMLAMA
            Kategoriler kategori = new Kategoriler();
            Markalar marka = new Markalar();
            Satislar satis = new Satislar();
            Tedarikciler tedarik = new Tedarikciler();
            Urunler urun = new Urunler();
            Personeller personel = new Personeller();
            #endregion
            Console.WriteLine("                                    M E H A  O U T D O O R");
            Console.WriteLine("1-Kullanıcı Profili Giriş");
            Console.WriteLine("2-Alışveriş Sayfası Giriş");
            string sifre = "15963";
            string secim = "e";
            int secenek = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (secenek < 1 || secenek > 2)
            {
                Console.WriteLine("YANLIŞ TUŞLAMA YAPTINIZ TEKRAR DENEYİNİZ");
                secenek = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            if (secenek == 1)
            {
                Console.WriteLine("SAYIN KULLANICI LÜTFEN ŞİFRENİZİ GİRİNİZ");
                sifre = Console.ReadLine();
                Console.Clear();
                while (sifre != "15963")
                {
                    Console.WriteLine("YANLIŞ TUŞLAMA YAPTINIZ TEKRAR DENEYİNİZ");
                    sifre = Console.ReadLine();
                    Console.Clear();
                }
                if (sifre == "15963")
                {
                    Console.WriteLine("1-Ekleme İşlemleri");
                    Console.WriteLine("2-Güncelleme İşlemleri");
                    Console.WriteLine("3-Görüntüleme İşlemleri");
                    secenek = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    while (secenek < 1 || secenek > 3)
                    {
                        Console.WriteLine("YANLIŞ TUŞLAMA YAPTINIZ TEKRAR DENEYİNİZ");
                        secenek = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                    }
                    if (secenek == 1)
                    {
                        Console.WriteLine("1-Kategori Ekle");
                        Console.WriteLine("2-Marka Ekle");
                        Console.WriteLine("3-Nakliyeci Ekle");
                        Console.WriteLine("4-Personel Ekle");
                        Console.WriteLine("5-Tedarikçi Ekle");
                        Console.WriteLine("6-Ürün Ekle");
                        secenek = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        while (secenek < 1 || secenek > 6)
                        {
                            Console.WriteLine("YANLIŞ TUŞLAMA YAPTINIZ TEKRAR DENEYİNİZ");
                            secenek = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }
                        if (secenek == 1)
                        {
                            while (secim == "e")
                            {
                                Console.WriteLine(kategori.kategoriEkle());
                                Console.WriteLine("DEVAM ETMEK İSTER MİSİN? E/H");
                                secim = Console.ReadLine();
                                secim.ToLower();
                                Console.Clear();
                            }
                        }
                        else if (secenek == 2)
                        {
                            while (secim == "e")
                            {
                                Console.WriteLine(marka.markaEkle());
                                Console.WriteLine("DEVAM ETMEK İSTER MİSİN? E/H");
                                secim = Console.ReadLine();
                                secim.ToLower();
                                Console.Clear();
                            }
                        }
                        else if (secenek == 3)
                        {
                            while (secim == "e")
                            {
                                Console.WriteLine(tedarik.tedarikciEkle());
                                Console.WriteLine("DEVAM ETMEK İSTER MİSİN? E/H");
                                secim= Console.ReadLine();
                                secim.ToLower();
                                Console.Clear();
                            }
                        }
                        else if (secenek == 4)
                        {
                            while (secim == "e")
                            {
                                Console.WriteLine(personel.personelEkle());
                                Console.WriteLine("DEVAM ETMEK İSTER MİSİN? E/H");
                                secim = Console.ReadLine();
                                secim.ToLower();
                                Console.Clear();
                            }
                        }
                        else if (secenek == 5)
                        {
                            Console.WriteLine(tedarik.tedarikciEkle());
                            Console.WriteLine("DEVAM ETMEK İSTER MİSİN? E/H");
                            secim = Console.ReadLine();
                            secim.ToLower();
                            Console.Clear();
                        }
                        else if (secenek == 6)
                        {
                            while (secim == "e")
                            {
                                Console.WriteLine(urun.urunEkle());
                                Console.WriteLine("DEVAM ETMEK İSTER MİSİN? E/H");
                                secim = Console.ReadLine();
                                secim.ToLower();
                                Console.Clear();
                            }
                        }


                    }
                    else if (secenek == 2)
                    {
                        Console.WriteLine("1-Personel Güncelleme");
                        Console.WriteLine("2-Tedarikçi Güncelleme");
                        Console.WriteLine("3-Ürün Güncelleme");
                        secenek = Convert.ToInt32(Console.ReadLine());
                        while (secenek < 1 || secenek > 3)
                        {
                            Console.WriteLine("YANLIŞ TUŞLAMA YAPTINIZ TEKRAR DENEYİNİZ");
                            secenek = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }
                        if (secenek == 1)
                        {
                            Console.WriteLine("1-Ad");
                            Console.WriteLine("2-Soyad");
                            Console.WriteLine("3-Telefon");
                            Console.WriteLine("4-Maaş");
                            Console.WriteLine("Güncellemek İstediğiniz Numarayı Tuşlayınız");
                            secenek = Convert.ToInt32(Console.ReadLine());
                            while (secenek < 1 || secenek > 4)
                            {
                                Console.WriteLine("YANLIŞ TUŞLAMA YAPTINIZ TEKRAR DENEYİNİZ");
                                secenek = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                        }
                        if (secenek == 2)
                        {

                        }
                        if (secenek == 3)
                        {

                        }
                    }
                    else if (secenek == 3)
                    {

                    }
                }
            }
            else if (secenek == 2)
            {

            }


            
        }
    }
}