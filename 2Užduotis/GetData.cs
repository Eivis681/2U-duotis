using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Užduotis
{
    public class GetData
    {
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Sport.db; Version = 3; New = True; Compress = True; ");
        public List<Player> GetDataFromDb()
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "Select Vardas, Ugis, Svoris, SportoSaka, Pozicija, Amzius From Zaidejai";
            SQLiteDataReader sQLiteDataReader = sqlite_cmd.ExecuteReader();
            List<Player> players = new List<Player>();
            while (sQLiteDataReader.Read())
            {
                string vardas = sQLiteDataReader.GetString(0);
                string ugis = sQLiteDataReader.GetString(1);
                string svoris = sQLiteDataReader.GetString(2);
                string sportoSaka = sQLiteDataReader.GetString(3);
                string pozicija = sQLiteDataReader.GetString(4);
                string amzius = sQLiteDataReader.GetString(5);
                players.Add(new Player { name = vardas, ugis = ugis, svoris = svoris, sportoSaka = sportoSaka, pozicija = pozicija, amzius = amzius});
            }
            sqlite_conn.Close();
            return players;
        }
        public List<Player> GetPlayerData()
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "Select Vardas, Ugis, Svoris, SportoSaka, Pozicija, Amzius From ZaidejasNe";
            SQLiteDataReader sQLiteDataReader = sqlite_cmd.ExecuteReader();
            List<Player> players = new List<Player>();
            while (sQLiteDataReader.Read())
            {
                string vardas = sQLiteDataReader.GetString(0);
                string ugis = sQLiteDataReader.GetString(1);
                string svoris = sQLiteDataReader.GetString(2);
                string sportoSaka = sQLiteDataReader.GetString(3);
                string pozicija = sQLiteDataReader.GetString(4);
                string amzius = sQLiteDataReader.GetString(5);
                players.Add(new Player { name = vardas, ugis = ugis, svoris = svoris, sportoSaka = sportoSaka, pozicija = pozicija, amzius = amzius });
            }
            sqlite_conn.Close();
            return players;
        }
        public List<Player> GetPlayerDataBySport(string sportoSakas)
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "Select Vardas, Ugis, Svoris, SportoSaka, Pozicija, Amzius From Zaidejai Where SportoSaka = '"+ sportoSakas+"'";
            SQLiteDataReader sQLiteDataReader = sqlite_cmd.ExecuteReader();
            List<Player> players = new List<Player>();
            while (sQLiteDataReader.Read())
            {
                string vardas = sQLiteDataReader.GetString(0);
                string ugis = sQLiteDataReader.GetString(1);
                string svoris = sQLiteDataReader.GetString(2);
                string sportoSaka = sQLiteDataReader.GetString(3);
                string pozicija = sQLiteDataReader.GetString(4);
                string amzius = sQLiteDataReader.GetString(5);
                players.Add(new Player { name = vardas, ugis = ugis, svoris = svoris, sportoSaka = sportoSaka, pozicija = pozicija, amzius = amzius });
            }
            sqlite_conn.Close();
            return players;
        }
        public List<Player> GetPlayerDataByPozition(string pozicijas)
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "Select Vardas, Ugis, Svoris, SportoSaka, Pozicija, Amzius From Zaidejai Where Pozicija = '" + pozicijas + "'";
            SQLiteDataReader sQLiteDataReader = sqlite_cmd.ExecuteReader();
            List<Player> players = new List<Player>();
            while (sQLiteDataReader.Read())
            {
                string vardas = sQLiteDataReader.GetString(0);
                string ugis = sQLiteDataReader.GetString(1);
                string svoris = sQLiteDataReader.GetString(2);
                string sportoSaka = sQLiteDataReader.GetString(3);
                string pozicija = sQLiteDataReader.GetString(4);
                string amzius = sQLiteDataReader.GetString(5);
                players.Add(new Player { name = vardas, ugis = ugis, svoris = svoris, sportoSaka = sportoSaka, pozicija = pozicija, amzius = amzius });
            }
            sqlite_conn.Close();
            return players;
        }
    }
}
