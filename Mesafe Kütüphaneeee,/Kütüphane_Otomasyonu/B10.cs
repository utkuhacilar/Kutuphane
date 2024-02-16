﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Kütüphane_Otomasyonu
{
    class B10
    {
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KütüphaneBilgileri.mdb";
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        public static bool Admin(string KullaniciAdi, int Sifre)
        {
            string veri = "select*from Admin where KullaniciAdi=@klnc AND Sifre=@sfr";
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = veri;
            komut.Parameters.AddWithValue("@klnc", KullaniciAdi);
            komut.Parameters.AddWithValue("@sfr", Sifre);
            DataSet sonucDS = new DataSet();
            OleDbDataAdapter adaptor = new OleDbDataAdapter(komut);
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            return sonuc;
        }

        public static void KitapEkle(string KitapAdı,int SayfaNo,string Yazar,string BasımEvi, string Adet, string RafNo)
        {
            baglanti.Open();
            string veri = "insert into Kitap (KitapAdı, SayfaNo, Yazar, BasımEvi, Adet,RafNo) values (@ktpa,@syf,@yzr,@bsmv,@adt,@rafno)";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@syf", SayfaNo);
            komut.Parameters.AddWithValue("@yzr", Yazar);
            komut.Parameters.AddWithValue("@bsmv", BasımEvi);
            komut.Parameters.AddWithValue("@adt", Adet);
            komut.Parameters.AddWithValue("@rafno", RafNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void KitapSil(string KitapAdı)
        {
            baglanti.Open();
            string veri = "delete from Kitap where KitapAdı=@ktpa";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void KitapGuncelle(string KitapAdı, int SayfaNo, string Yazar, string BasımEvi, string Adet, string RafNo)
        {
            baglanti.Open();
            string veri = "update Kitap set KitapAdı=@ktpa,SayfaNo=@syf,Yazar=@yzr,BasımEvi=@bsmv,RafNo=@rafno,Adet=@adt where KitapAdı=@ktpa ";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@syf", SayfaNo);
            komut.Parameters.AddWithValue("@yzr", Yazar);
            komut.Parameters.AddWithValue("@bsmv", BasımEvi);
            komut.Parameters.AddWithValue("@adt", Adet);
            komut.Parameters.AddWithValue("@rafno", RafNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void emanetEkle(string KitapAdı, int KitapNo, string ÜyeAdı,int ÜyeNo,string AldığıTarih, string SonTeslimTarih)
        {
            baglanti.Open();
            string veri = "insert into Emanetler (KitapAdı,KitapNo,ÜyeAdı,ÜyeNo,AldığıTarih,SonTeslimTarih) values (@ktpa,@ktpn,@uye,@uyen,@trh,@ttrh)";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@ktpn", KitapNo);
            komut.Parameters.AddWithValue("@uye", ÜyeAdı);
            komut.Parameters.AddWithValue("@uyen", ÜyeNo);
            komut.Parameters.AddWithValue("@trh", AldığıTarih);
            komut.Parameters.AddWithValue("@ttrh", SonTeslimTarih);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public static void emanetSil(string KitapAdı)
        {
            baglanti.Open();
            string veri = "delete from Emanetler where KitapAdı=@ktpa";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void emanetGuncelle(string KitapAdı, int KitapNo, string ÜyeAdı, int ÜyeNo, string AldığıTarih, string SonTeslimTarih)
        {
            baglanti.Open();
            string veri = "update Emanetler set KitapAdı=@ktpa,KitapNo=@ktpn,ÜyeAdı=@uye,ÜyeNo=@uyen,SonTeslimTarih=@ttrh,AldığıTarih=@trh where KitapAdı=@ktpa";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@ktpa", KitapAdı);
            komut.Parameters.AddWithValue("@ktpn", KitapNo);
            komut.Parameters.AddWithValue("@uye", ÜyeAdı);
            komut.Parameters.AddWithValue("@uyen", ÜyeNo);
            komut.Parameters.AddWithValue("@trh", AldığıTarih);
            komut.Parameters.AddWithValue("@ttrh", SonTeslimTarih);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void üyeEkle(string ÜyeAdSoyad, string Sınıf,int OkulNo)
        {
            baglanti.Open();
            string veri = "insert into Üyeler (ÜyeAdSoyad,Sınıf,OkulNo) values (@uyea,@sınıf,@okulno)";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@uyea", ÜyeAdSoyad);
            komut.Parameters.AddWithValue("@sınıf", Sınıf);
            komut.Parameters.AddWithValue("@okulno", OkulNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void üyeSil(string ÜyeAdSoyad)
        {
            baglanti.Open();
            string veri = "delete from Üyeler where ÜyeAdSoyad=@uyea";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@uyea", ÜyeAdSoyad);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static void üyeGuncelle(string ÜyeAdSoyad, string Sınıf, int OkulNo)
        {
            baglanti.Open();
            string veri = "update Üyeler set ÜyeAdı=@uyea,ÜyeSoyadı=uyes,Sınıf=@sınıf,OkulNo=@okulno where ÜyeAdı=@uyea";
            OleDbCommand komut = new OleDbCommand(veri, baglanti);
            komut.Parameters.AddWithValue("@uyea", ÜyeAdSoyad);
            komut.Parameters.AddWithValue("@sınıf", Sınıf);
            komut.Parameters.AddWithValue("@okulno", OkulNo);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
