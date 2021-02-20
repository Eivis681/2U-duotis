using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Užduotis
{
    public class AddData
    {
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Sport.db; Version = 3; New = True; Compress = True; ");
        public void AddPlayerData(List<Player> players)
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Zaidejai (Vardas, Ugis, Svoris, SportoSaka, Pozicija, Amzius) VALUES(?,?,?,?,?,?); ";
            sqlite_cmd.Parameters.AddWithValue("Vardas", players[0].name);
            sqlite_cmd.Parameters.AddWithValue("Ugis", players[0].ugis);
            sqlite_cmd.Parameters.AddWithValue("Svoris", players[0].svoris);
            sqlite_cmd.Parameters.AddWithValue("SportoSaka", players[0].sportoSaka);
            sqlite_cmd.Parameters.AddWithValue("Pozicija", players[0].pozicija);
            sqlite_cmd.Parameters.AddWithValue("Amzius", players[0].amzius);
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}
