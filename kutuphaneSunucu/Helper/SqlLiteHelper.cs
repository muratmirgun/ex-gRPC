using System;
using System.Collections.Generic;
using Kutuphane;
using Microsoft.Data.Sqlite;

namespace kutuphaneSunucu.Helper
{
    public class SqlLiteHelper
    {
        public static List<ResponseKitap> SqlKomutCalistirSorgu(int id)
        {
            List<ResponseKitap> kitapListe = new List<ResponseKitap>();
            using (var DBbaglanti = new SqliteConnection("Data Source=db/db.sqlite;"))
            {
                SqliteCommand command = new SqliteCommand("SELECT * FROM kitaplar WHERE ID=@id", DBbaglanti);
                command.Parameters.AddWithValue("@id",id);
                DBbaglanti.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResponseKitap kitabim = new ResponseKitap();
                    kitabim.ID = reader[0] != null ? Convert.ToInt32(reader[0]) : 0 ;
                    kitabim.KitapAdi = reader[1] != null ? reader[1].ToString() : " " ; 
                    kitabim.YayinEvi = reader[2] != null ? reader[2].ToString() : " " ;
                    kitabim.Yazar = reader[3] != null ? reader[3].ToString() : " " ;
                    kitabim.ISBN = reader[4] != null ? reader[4].ToString() : " " ;
                    kitabim.Baski = reader[5] != null ? reader[5].ToString() : " " ;
                    kitabim.Dil = reader[6] != null ? reader[6].ToString() : " " ;
                    kitabim.SayfaSayisi = reader[7] != null ? reader[7].ToString() : " " ;
                    kitapListe.Add(kitabim);
                }
                return kitapListe;
            }
        }

        public static List<ResponseKitap> SqlKomutCalistirSorguTumKitaplar()
        {
            List<ResponseKitap> kitapListe = new List<ResponseKitap>();
            using (var DBbaglanti = new SqliteConnection("Data Source=db/db.sqlite;"))
            {
                SqliteCommand command = new SqliteCommand("SELECT * FROM kitaplar", DBbaglanti);
                DBbaglanti.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResponseKitap kitabim = new ResponseKitap();
                    kitabim.ID = reader[0] != null ? Convert.ToInt32(reader[0]) : 0 ;
                    kitabim.KitapAdi = reader[1] != null ? reader[1].ToString() : " " ; 
                    kitabim.YayinEvi = reader[2] != null ? reader[2].ToString() : " " ;
                    kitabim.Yazar = reader[3] != null ? reader[3].ToString() : " " ;
                    kitabim.ISBN = reader[4] != null ? reader[4].ToString() : " " ;
                    kitabim.Baski = reader[5] != null ? reader[5].ToString() : " " ;
                    kitabim.Dil = reader[6] != null ? reader[6].ToString() : " " ;
                    kitabim.SayfaSayisi = reader[7] != null ? reader[7].ToString() : " " ;
                    kitapListe.Add(kitabim);
                }
                return kitapListe;
            }
        }

        public static bool SqlKomutCalistirSil(int id)
        {
            using (var DBbaglanti = new SqliteConnection("Data Source=db/db.sqlite;"))
            {
                SqliteCommand command = new SqliteCommand("DELETE FROM kitaplar WHERE ID=@id", DBbaglanti);
                command.Parameters.AddWithValue("@id",id);
                DBbaglanti.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public static bool SqlKomutCalistirEkle(ResponseKitap kitabim)
        {
            using (var DBbaglanti = new SqliteConnection("Data Source=db/db.sqlite;"))
            {
                SqliteCommand command = new SqliteCommand("INSERT INTO kitaplar (kitapAdi, yayinEvi, yazar, isbn, baski, dil, sayfaSayisi) VALUES(@kitapAdi, @yayinEvi, @yazar, @isbn, @baski, @dil, @sayfaSayisi)", DBbaglanti);                
                command.Parameters.AddWithValue("@kitapAdi",kitabim.KitapAdi);
                command.Parameters.AddWithValue("@yayinEvi",kitabim.YayinEvi);
                command.Parameters.AddWithValue("@yazar",kitabim.Yazar);
                command.Parameters.AddWithValue("@isbn",kitabim.ISBN);
                command.Parameters.AddWithValue("@baski",kitabim.Baski);
                command.Parameters.AddWithValue("@dil",kitabim.Dil);
                command.Parameters.AddWithValue("@sayfaSayisi",kitabim.SayfaSayisi);
                DBbaglanti.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public static bool SqlKomutCalistirGuncelle(ResponseKitap kitabim)
        {
            using (var DBbaglanti = new SqliteConnection("Data Source=db/db.sqlite;"))
            {
                SqliteCommand command = new SqliteCommand("UPDATE kitaplar SET kitapAdi=@kitapAdi, yayinEvi=@yayinEvi, yazar=@yazar, isbn=@isbn, baski=@baski, dil=@dil, sayfaSayisi=@sayfaSayisi WHERE ID=@id", DBbaglanti);                
                command.Parameters.AddWithValue("@id",kitabim.ID);                
                command.Parameters.AddWithValue("@kitapAdi",kitabim.KitapAdi);
                command.Parameters.AddWithValue("@yayinEvi",kitabim.YayinEvi);
                command.Parameters.AddWithValue("@yazar",kitabim.Yazar);
                command.Parameters.AddWithValue("@isbn",kitabim.ISBN);
                command.Parameters.AddWithValue("@baski",kitabim.Baski);
                command.Parameters.AddWithValue("@dil",kitabim.Dil);
                command.Parameters.AddWithValue("@sayfaSayisi",kitabim.SayfaSayisi);
                DBbaglanti.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
        }
    }
}