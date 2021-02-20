using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Užduotis
{
    public class DeleteFromDb
    {
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Sport.db; Version = 3; New = True; Compress = True; ");
        public void DeletePlayer(string name)
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "DELETE FROM ZaidejasNe WHERE Vardas = '" + name + "'";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}
