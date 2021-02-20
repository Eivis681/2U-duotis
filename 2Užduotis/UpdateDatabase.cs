using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Užduotis
{
    public class UpdateDatabase
    {
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Sport.db; Version = 3; New = True; Compress = True; ");
        public void UpdatePlayerData(List<Player> zaidejas)
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "Update ZaidejasNe Set Ugis=?, Svoris=?, SportoSaka=?, Pozicija=?, Amzius=? WHERE Vardas=?";
            sqlite_cmd.Parameters.AddWithValue("Ugis", zaidejas[0].ugis);
            sqlite_cmd.Parameters.AddWithValue("Svoris", zaidejas[0].svoris);
            sqlite_cmd.Parameters.AddWithValue("SportoSaka", zaidejas[0].sportoSaka);
            sqlite_cmd.Parameters.AddWithValue("Pozicija", zaidejas[0].pozicija);
            sqlite_cmd.Parameters.AddWithValue("Amzius", zaidejas[0].amzius);
            sqlite_cmd.Parameters.AddWithValue("Vardas", zaidejas[0].name);
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}
